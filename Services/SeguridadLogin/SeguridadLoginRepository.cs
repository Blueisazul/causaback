using System.Data;
using CausaViva.DTOs.SeguridadLoginUsuario;
using CausaViva.DTOs.UserMenu;
using Microsoft.Data.SqlClient;

namespace CausaViva.Services.SeguridadLoginUsuario
{
    public class SeguridadLoginRepository : ISeguridadLoginRepository
    {
        private readonly string _connectionString;

        public SeguridadLoginRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<SeguridadLoginDTO> GetUsuarioLogin(String IdUsuario)
        {
            SeguridadLoginDTO resultado = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                // PRIMER COMANDO: Obtener datos del usuario
                using (var command = new SqlCommand("dbo.sp_obtenerUsuarioLogin", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pUsuario", IdUsuario);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            resultado = new SeguridadLoginDTO
                            {
                                IdUser = reader.GetInt32(reader.GetOrdinal("IdUser")),
                                IdUserType = reader.GetInt32(reader.GetOrdinal("IdUserType")),
                                Login = reader.GetString(reader.GetOrdinal("Login")),
                                Password = reader.GetString(reader.GetOrdinal("Password")),
                                Menus = new List<UserMenuDTO>() // Inicializa la lista
                            };
                        }
                    }
                }

                // Si no encontró usuario, salimos
                if (resultado == null)
                    return null;

                // SEGUNDO COMANDO: Obtener el menú del usuario
                using (var cmdMenu = new SqlCommand("dbo.sp_obtenerUserMenu", connection))
                {
                    cmdMenu.CommandType = CommandType.StoredProcedure;
                    cmdMenu.Parameters.AddWithValue("@pUserType", resultado.IdUserType);

                    using (var readerMenu = await cmdMenu.ExecuteReaderAsync())
                    {
                        while (await readerMenu.ReadAsync())
                        {
                            resultado.Menus.Add(new UserMenuDTO
                            {
                                IdUserMenu = readerMenu.GetInt32(readerMenu.GetOrdinal("IdUserMenu")),
                                IdUserType = readerMenu.GetInt32(readerMenu.GetOrdinal("IdUserType")),
                                IdMenu = readerMenu.GetInt32(readerMenu.GetOrdinal("IdMenu")),
                                Nombre = readerMenu.GetString(readerMenu.GetOrdinal("Nombre")),
                                Icono = readerMenu.GetString(readerMenu.GetOrdinal("Icono")),
                                Ruta = readerMenu.GetString(readerMenu.GetOrdinal("Ruta")),
                                Estado = readerMenu.GetBoolean(readerMenu.GetOrdinal("Estado"))
                            });
                        }
                    }
                }
            }

            return resultado;
        }

        public async Task<SeguridadLoginDTO> GetOrganizacionLogin(string IdUsuario)
        {
            SeguridadLoginDTO usuario = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                // PRIMER COMANDO: Obtener usuario
                using (var command = new SqlCommand("dbo.sp_obtenerOrganizacionLogin", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pUsuario", IdUsuario);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            usuario = new SeguridadLoginDTO
                            {
                                IdUser = reader.GetInt32(reader.GetOrdinal("IdUser")),
                                IdUserType = reader.GetInt32(reader.GetOrdinal("IdUserType")),
                                Login = reader.GetString(reader.GetOrdinal("Login")),
                                Password = reader.GetString(reader.GetOrdinal("Password")),
                                Menus = new List<UserMenuDTO>()
                            };
                        }
                    }
                }

                // Si no se encontró usuario, salimos
                if (usuario == null)
                    return null;

                // SEGUNDO COMANDO: Obtener los menús del usuario
                using (var cmdMenu = new SqlCommand("dbo.sp_obtenerUserMenu", connection))
                {
                    cmdMenu.CommandType = CommandType.StoredProcedure;
                    cmdMenu.Parameters.AddWithValue("@pUserType", usuario.IdUserType);

                    using (var readerMenu = await cmdMenu.ExecuteReaderAsync())
                    {
                        while (await readerMenu.ReadAsync())
                        {
                            usuario.Menus.Add(new UserMenuDTO
                            {
                                IdUserMenu = readerMenu.GetInt32(readerMenu.GetOrdinal("IdUserMenu")),
                                IdUserType = readerMenu.GetInt32(readerMenu.GetOrdinal("IdUserType")),
                                IdMenu = readerMenu.GetInt32(readerMenu.GetOrdinal("IdMenu")),
                                Nombre = readerMenu.GetString(readerMenu.GetOrdinal("Nombre")),
                                Icono = readerMenu.GetString(readerMenu.GetOrdinal("Icono")),
                                Ruta = readerMenu.GetString(readerMenu.GetOrdinal("Ruta")),
                                Estado = readerMenu.GetBoolean(readerMenu.GetOrdinal("Estado"))
                            });
                        }
                    }
                }
            }

            return usuario;
        }
    }
}
