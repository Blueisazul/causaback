using System.Data;
using CausaViva.DTOs.Organizacion;
using CausaViva.DTOs.Usuario;
using CausaViva.Models;
using Microsoft.Data.SqlClient;

namespace CausaViva.Services.Organizacion
{
    public class OrganizacionService : IOrganizacionService
    {
        private readonly string _connectionString;

        public OrganizacionService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<OrganizacionDTO>> GetOrganizacionId(String IdOrganizacion)
        {
            var organizacion = new List<OrganizacionDTO>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("dbo.sp_obtenerorganizacion", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pIdOrganizacion", IdOrganizacion);

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            organizacion.Add(new OrganizacionDTO
                            {
                                IdOrganizacion = reader.GetString(reader.GetOrdinal("IdOrganizacion")),
                                RazonSocial = reader.GetString(reader.GetOrdinal("RazonSocial")),
                                Telefono = reader.GetString(reader.GetOrdinal("Telefono")),
                                Direccion = reader.GetString(reader.GetOrdinal("Direccion")),
                                IdDistrito = reader.GetInt32(reader.GetOrdinal("IdDistrito")),
                                NombreDistrito = reader.GetString(reader.GetOrdinal("NombreDistrito"))
                            });


                        }
                    }

                }
            }
            return organizacion;
        }

        public async Task InsertarOrganizacionAsync(OrganizacionInsertarDTO organizacion)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("dbo.sp_insertarorganizacion", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@pIdOrganizacion", organizacion.IdOrganizacion);
                    command.Parameters.AddWithValue("@pRazonSocial", organizacion.RazonSocial);
                    command.Parameters.AddWithValue("@pTelefono", organizacion.Telefono);
                    command.Parameters.AddWithValue("@pDireccion", organizacion.Direccion);
                    command.Parameters.AddWithValue("@pIdDistrito", organizacion.IdDistrito);
                    command.Parameters.AddWithValue("@pContrasenia", organizacion.Contrasenia);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task ActualizarOrganizacion(OrganizacionActualizarDTO organizacion)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("dbo.sp_actualizarorganizacion", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@pIdOrganizacion", organizacion.IdOrganizacion);
                    command.Parameters.AddWithValue("@pRazonSocial", organizacion.RazonSocial);
                    command.Parameters.AddWithValue("@pTelefono", organizacion.Telefono);
                    command.Parameters.AddWithValue("@pDireccion", organizacion.Direccion);
                    command.Parameters.AddWithValue("@pIdDistrito", organizacion.IdDistrito);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task ActualizarEstadoOrgVolReq(OrgVolReqActualizarEstadoDTO organizacion)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("dbo.sp_actualizarestadovoluntariadorequisitos", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@pIdOrganizacion", organizacion.IdOrganizacion);
                    command.Parameters.AddWithValue("@pEstado", organizacion.Estado);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task CambioContraseniaOrg(CambioContraseniaOrg organizacion)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("dbo.sp_cambiocontraseniaorganzacion", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@pIdOrganizacion", organizacion.IdOrganizacion);
                    command.Parameters.AddWithValue("@pContrasenia", organizacion.Contrasenia);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }

        }
    }
}
