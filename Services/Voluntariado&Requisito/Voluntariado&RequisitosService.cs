using System.Data;
using CausaViva.DTOs.Voluntariado_Requisito.Voluntariado;
using CausaViva.Models;
using Microsoft.Data.SqlClient;

namespace CausaViva.Services.Voluntariado_Requisito
{
    public class Voluntariado_RequisitosService : IVoluntariado_RequisitoService
    {
        private readonly string _connectionString;
        public Voluntariado_RequisitosService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<VoluntariadoDetalleDTO>> GetVoluntariadoIdPanelUsuario(Int32 IdVoluntariado)
        {
            var voluntariadodetalle = new List<VoluntariadoDetalleDTO>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("dbo.sp_obtenervoluntariadousuarioid", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pIdVoluntariado", IdVoluntariado);

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            voluntariadodetalle.Add(new VoluntariadoDetalleDTO
                            {
                                IdVoluntariado = reader.GetInt32(reader.GetOrdinal("IdVoluntariado")),
                                RazonSocial = reader.GetString(reader.GetOrdinal("RazonSocial")),
                                TituloPropuesta = reader.GetString(reader.GetOrdinal("TituloPropuesta")),
                                DescripcionPropuesta = reader.GetString(reader.GetOrdinal("DescripcionPropuesta")),
                                Direccion = reader.GetString(reader.GetOrdinal("Direccion")),
                                FechaInicio = reader.GetDateTime(reader.GetOrdinal("FechaInicio")),
                                FechaFinal = reader.GetDateTime(reader.GetOrdinal("FechaFinal")),
                                DescripcionRequisito = reader.GetString(reader.GetOrdinal("Descripcion"))
                            });


                        }
                    }

                }
            }
            return voluntariadodetalle;
        }
        public async Task<IEnumerable<VoluntariadoDTO>> GetVoluntariadoAllPanelUsuario()
        {
            var voluntariado = new List<VoluntariadoDTO>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("dbo.sp_obtenervoluntariadousuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            voluntariado.Add(new VoluntariadoDTO
                            {
                                IdVoluntariado = reader.GetInt32(reader.GetOrdinal("IdVoluntariado")),
                                RazonSocial = reader.GetString(reader.GetOrdinal("RazonSocial")),
                                TituloPropuesta = reader.GetString(reader.GetOrdinal("TituloPropuesta")),
                                DescripcionPropuesta = reader.GetString(reader.GetOrdinal("DescripcionPropuesta")),
                                Direccion = reader.GetString(reader.GetOrdinal("Direccion")),
                                FechaInicio = reader.GetDateTime(reader.GetOrdinal("FechaInicio")),
                                FechaFinal = reader.GetDateTime(reader.GetOrdinal("FechaFinal"))
                            });


                        }
                    }

                }
            }
            return voluntariado;
        }
        public async Task<IEnumerable<VoluntariadoActualizarDTO>> GetVoluntariadoPanelOrg(String IdOrganizacion)
        {
            var voluntariado = new List<VoluntariadoActualizarDTO>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("dbo.sp_obtenervoluntariadorequisitosId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pIdOrganizacion", IdOrganizacion);

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            voluntariado.Add(new VoluntariadoActualizarDTO
                            {
                                IdVoluntariado = reader.GetInt32(reader.GetOrdinal("IdVoluntariado")),
                                TituloPropuesta = reader.GetString(reader.GetOrdinal("TituloPropuesta")),
                                DescripcionPropuesta = reader.GetString(reader.GetOrdinal("DescripcionPropuesta")),
                                Direccion = reader.GetString(reader.GetOrdinal("Direccion")),
                                FechaInicio = reader.GetDateTime(reader.GetOrdinal("FechaInicio")),
                                FechaFinal = reader.GetDateTime(reader.GetOrdinal("FechaFinal")),
                                DescripcionRequisito = reader.GetString(reader.GetOrdinal("Descripcion")),
                                Estado = reader.GetBoolean(reader.GetOrdinal("Estado"))
                            });


                        }
                    }

                }
            }
            return voluntariado;
        }

        public async Task<IEnumerable<VoluntariadoActualizarDTO>> GetVoluntariadoIdPanelOrg(Int32 IdVoluntariado)
        {
            var voluntariado = new List<VoluntariadoActualizarDTO>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("dbo.sp_obtenerdetalleidvoluntariado", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pIdVoluntariado", IdVoluntariado);

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            voluntariado.Add(new VoluntariadoActualizarDTO
                            {
                                IdVoluntariado = reader.GetInt32(reader.GetOrdinal("IdVoluntariado")),
                                TituloPropuesta = reader.GetString(reader.GetOrdinal("TituloPropuesta")),
                                DescripcionPropuesta = reader.GetString(reader.GetOrdinal("DescripcionPropuesta")),
                                Direccion = reader.GetString(reader.GetOrdinal("Direccion")),
                                FechaInicio = reader.GetDateTime(reader.GetOrdinal("FechaInicio")),
                                FechaFinal = reader.GetDateTime(reader.GetOrdinal("FechaFinal")),
                                DescripcionRequisito = reader.GetString(reader.GetOrdinal("Descripcion"))
                            });


                        }
                    }

                }
            }
            return voluntariado;
        }

        public async Task InsertarVoluntariadoRequisitoPanelOrg(VoluntariadoInsertarDTO voluntariado)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("dbo.sp_insertarvoluntariadorequisito", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@pIdOrganizacion", voluntariado.IdOrganizacion);
                    command.Parameters.AddWithValue("@pTituloPropuesta", voluntariado.TituloPropuesta);
                    command.Parameters.AddWithValue("@pDescripcionPropuesta", voluntariado.DescripcionPropuesta);
                    command.Parameters.AddWithValue("@pDireccion", voluntariado.Direccion);
                    command.Parameters.AddWithValue("@pFechaInicio", voluntariado.FechaInicio);
                    command.Parameters.AddWithValue("@pFechaFinal", voluntariado.FechaFinal);
                    command.Parameters.AddWithValue("@pDescripcionRequisito", voluntariado.DescripcionRequisito);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task ActualizarVoluntariadoRequisitoPanelOrg(VoluntariadoActualizarDTO voluntariado)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("dbo.sp_actualizarvoluntariadorequisito", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@pIdVoluntariado", voluntariado.IdVoluntariado);
                    command.Parameters.AddWithValue("@pTituloPropuesta", voluntariado.TituloPropuesta);
                    command.Parameters.AddWithValue("@pDescripcionPropuesta", voluntariado.DescripcionPropuesta);
                    command.Parameters.AddWithValue("@pDireccion", voluntariado.Direccion);
                    command.Parameters.AddWithValue("@pFechaInicio", voluntariado.FechaInicio);
                    command.Parameters.AddWithValue("@pFechaFinal", voluntariado.FechaFinal);
                    command.Parameters.AddWithValue("@pDescripcionRequisito", voluntariado.DescripcionRequisito);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task ActualizarEstadoVoluntariadoRequisitoPanelOrg(VoluntariadoReqDTO voluntariado)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("dbo.sp_actualizarestadovolreq", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@pIdVoluntariado", voluntariado.IdVoluntariado);
                    command.Parameters.AddWithValue("@pEstado", voluntariado.Estado);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
