using Microsoft.Data.SqlClient;
using TesterProject.BusinessEntities.Utils;

namespace TesterProject.DataAccess.Utils
{
    public class AuthService : DatabaseConnector
    {
        public async Task<Usuario?> GetUsuario(string nombreUsuario)
        {
            string? _connectionString = await GetConnectionStringAsync();
            using SqlConnection connection = new(_connectionString);
            connection.Open();
            using SqlCommand cmd = new("SELECT * FROM Usuarios WHERE UserName = @UserName", connection);
            _ = cmd.Parameters.AddWithValue("@UserName", nombreUsuario);
            using SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                return null;
            }

            Usuario usuario = new()
            {
                Id = (int)reader["Id"],
                NombreUsuario = (string)reader["UserName"],
                PasswordHash = (string)reader["PasswordHash"],
                PasswordSalt = (byte[])reader["PasswordSalt"],
                FechaCreacion = reader["FechaCreacion"] as DateTime?
            };
            connection.Close();
            return usuario;
        }

        public async Task<List<Rol>> GetRolesByUsuarioId(int usuarioId, SqlConnection? existingConn = null)
        {
            List<Rol> roles = [];
            string? _connectionString = await GetConnectionStringAsync();
            using SqlConnection connection = new(_connectionString);
            connection.Open();
            using SqlCommand cmd = new(@"
                SELECT r.Id, r.Nombre FROM Roles r
                INNER JOIN UsuarioRoles ur ON ur.RolId = r.Id
                WHERE ur.UsuarioId = @UsuarioId", connection);
            _ = cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                roles.Add(new Rol { Id = (int)reader["Id"], Nombre = (string)reader["Nombre"] });
            }
            connection.Close();
            return roles;
        }

        public async Task<List<string>> GetRolesPermitidosParaPagina(string ruta)
        {
            List<string> roles = [];
            string? _connectionString = await GetConnectionStringAsync();
            using SqlConnection connection = new(_connectionString);
            connection.Open();
            using SqlCommand cmd = new(@"
                SELECT r.Nombre FROM PaginaRoles pr
                INNER JOIN Roles r ON r.Id = pr.RolId
                WHERE pr.Ruta = @Ruta", connection);
            _ = cmd.Parameters.AddWithValue("@Ruta", ruta);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                roles.Add((string)reader["Nombre"]);
            }
            return roles;
        }

        public async Task<bool> UsuarioTieneAcceso(Usuario usuario, string ruta)
        {
            List<string> rolesPermitidos = await GetRolesPermitidosParaPagina(ruta);
            if (usuario != null)
            {
                return usuario.Roles.Any(r => rolesPermitidos.Contains(r.Nombre)); 
            }
            else
            {
                return false;
            }
        }

        // TODO: Usar el hasher que ya tengo previsto para el winform
    }
}