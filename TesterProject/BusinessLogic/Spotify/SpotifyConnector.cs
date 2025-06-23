using System.Diagnostics;
using System.Net;
using System.Text;
using SpotifyAPI.Web;
using TesterProject.BusinessEntities.Utils;
using TesterProject.BusinessLogic.PasswordManager;

namespace TesterProject.BusinessLogic.Spotify
{
    public class SpotifyConnector(string accessToken)
    {
        private readonly SpotifyClient _spotifyClient = new(accessToken);

        public async Task CreatingConnectionInformation()
        {
            try
            {
                string? clientId = await Task.FromResult(CredentialManagerHelper.ReadSecret(ConstantValues.CM_SpotifyClientId));
                string? clientSecret = await Task.FromResult(CredentialManagerHelper.ReadSecret(ConstantValues.CM_SpotifyClientSecret));
                SpotifyClientConfig? config = SpotifyClientConfig
                    .CreateDefault()
                    .WithAuthenticator(new ClientCredentialsAuthenticator(clientId, clientSecret));

                SpotifyClient? spotify = new(config);

                // ACÁ YA TENGO LA INFO
                FullArtist? artist = await spotify.Artists.Get("");
            }
            catch
            {
                throw;
            }
        }

        public async Task CreatingConnectionPlayback()
        {
            try
            {
                string? clientId = await Task.FromResult(CredentialManagerHelper.ReadSecret(ConstantValues.CM_SpotifyClientId));
                string? clientSecret = await Task.FromResult(CredentialManagerHelper.ReadSecret(ConstantValues.CM_SpotifyClientSecret));
                string redirectUri = "http://127.0.0.1:5000/callback/";

                LoginRequest loginRequest = new(new Uri(redirectUri), clientId ?? throw new Exception("No hay clientId"), LoginRequest.ResponseType.Code)
                {
                    Scope =
                    [
                            Scopes.UserReadPlaybackState,
                            Scopes.UserModifyPlaybackState,
                            Scopes.UserReadCurrentlyPlaying
                    ]
                };

                Uri loginUri = loginRequest.ToUri();
                Console.WriteLine("Abrí este enlace para autorizar la app:");
                Console.WriteLine(loginUri);
                _ = Process.Start(new ProcessStartInfo
                {
                    FileName = loginUri.ToString(),
                    UseShellExecute = true
                });

                HttpListener http = new();
                http.Prefixes.Add(redirectUri);
                http.Start();

                HttpListenerContext context = await http.GetContextAsync();
                string? code = context.Request.QueryString["code"];

                if (string.IsNullOrEmpty(code))
                {
                    throw new InvalidOperationException("Authorization code is missing or invalid.");
                }

                string responseString = "<html><body>Fin LOGIN</body></html>";
                byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                context.Response.ContentLength64 = buffer.Length;
                await context.Response.OutputStream.WriteAsync(buffer);
                context.Response.OutputStream.Close();
                http.Stop();

                AuthorizationCodeTokenResponse tokenResponse = await new OAuthClient().RequestToken(
                    new AuthorizationCodeTokenRequest(
                        clientId,
                        clientSecret,
                        code,
                        new Uri(redirectUri)
                    )
                );

                SpotifyClientConfig config = SpotifyClientConfig.CreateDefault().WithToken(tokenResponse.AccessToken);
                SpotifyClient spotify = new(config);

                CurrentlyPlayingContext playback = await spotify.Player.GetCurrentPlayback();
                if (playback?.Item is FullTrack track)
                {
                    // YA HAY REPRODUCCIÓN
                }
                else
                {
                    // PAUSADO O PARADO
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<FullTrack> GetTrackAsync()
        {
            SpotifyClient spotify = new(accessToken);
            FullTrack track = await spotify.Tracks.Get("1s6ux0lNiTziSrd7iUAADH");
            return track;
        }
    }
}