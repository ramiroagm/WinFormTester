using Microsoft.JSInterop;
using TesterProject.BusinessEntities.Utils;
using TesterProject.DataAccess.Utils;


public class SessionState
{
    private readonly IJSRuntime _jsRuntime;
    private readonly AuthService _authService;
    private bool _initialized;
    private bool _isClientSideInitialized;

    public Usuario? UsuarioActual { get; private set; }
    public bool IsAuthenticated => UsuarioActual != null;

    public SessionState(IJSRuntime jsRuntime, AuthService authService)
    {
        _jsRuntime = jsRuntime;
        _authService = authService;
    }

    // Server-side initialization (no JS interop)
    public async Task InitializeAsync()
    {
        if (_initialized) return;
        _initialized = true;
    }

    // Client-side initialization (JS interop allowed)
    public async Task InitializeClientSideAsync()
    {
        if (_isClientSideInitialized) return;

        var storedUser = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "user");
        if (!string.IsNullOrEmpty(storedUser))
        {
            UsuarioActual = await _authService.GetUsuario(storedUser);
            if (UsuarioActual != null)
            {
                UsuarioActual.Roles = await _authService.GetRolesByUsuarioId(UsuarioActual.Id);
            }
        }
        _isClientSideInitialized = true;
    }

    public async Task SetUserAsync(Usuario? user)
    {
        UsuarioActual = user;
        if (user != null)
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "user", user.NombreUsuario);
        else
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "user");
    }
}