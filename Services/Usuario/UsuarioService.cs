using System.Data;
using CausaViva.DTOs.Usuario;
using Microsoft.Data.SqlClient;

namespace CausaViva.Services.Usuario
{
    public class UsuarioService : IUsuarioService
    {
        private readonly string _connectionString;

        public UsuarioService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<UsuarioDTO>> GetUsuarioId(String IdUsuario)
        {
            var usuario = new List<UsuarioDTO>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("dbo.sp_obtenerusuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pIdUsuario", IdUsuario);

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            usuario.Add(new UsuarioDTO
                            {
                                IdUsuario = reader.GetString(reader.GetOrdinal("IdUsuario")),
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                Apellido = reader.GetString(reader.GetOrdinal("Apellido")),
                                Direccion = reader.GetString(reader.GetOrdinal("Direccion")),
                                Telefono = reader.GetString(reader.GetOrdinal("Telefono")),
                                IdDistrito = reader.GetInt32(reader.GetOrdinal("IdDistrito")),
                                NombreDistrito = reader.GetString(reader.GetOrdinal("NombreDistrito"))
                            });

                            
                        }
                    }

                }
            }
            return usuario;
        }

        public async Task InsertarUsuarioAsync(UsuarioInsertarDTO usuario) 
        { 
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("dbo.sp_insertarusuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@pIdUsuario", usuario.IdUsuario);
                    command.Parameters.AddWithValue("@pNombre", usuario.Nombre);
                    command.Parameters.AddWithValue("@pApellido", usuario.Apellido);
                    command.Parameters.AddWithValue("@pDireccion", usuario.Direccion);
                    command.Parameters.AddWithValue("@pTelefono", usuario.Telefono);
                    command.Parameters.AddWithValue("@pIdDistrito", usuario.IdDistrito);
                    command.Parameters.AddWithValue("@pContrasenia", usuario.Contrasenia);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync(); 
                }
            }
        }

        public async Task ActualizarUsuario(UsuarioActualizarDTO usuario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("dbo.sp_actualizarusuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@pIdUsuario", usuario.IdUsuario);
                    command.Parameters.AddWithValue("@pNombre", usuario.Nombre);
                    command.Parameters.AddWithValue("@pApellido", usuario.Apellido);
                    command.Parameters.AddWithValue("@pDireccion", usuario.Direccion);
                    command.Parameters.AddWithValue("@pTelefono", usuario.Telefono);
                    command.Parameters.AddWithValue("@pIdDistrito", usuario.IdDistrito);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task ActualizarEstadoUsuario(UsuarioEstadoDTO usuario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("dbo.sp_actualizarestadousuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@pIdUsuario", usuario.IdUsuario);
                    command.Parameters.AddWithValue("@pEstado", usuario.Estado);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }

        }

        public async Task CambioContrasenia(UsuarioContraseniaDTO usuario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("dbo.sp_cambiocontraseniausuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@pIdUsuario", usuario.IdUsuario);
                    command.Parameters.AddWithValue("@pContrasenia", usuario.Contrasenia);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
