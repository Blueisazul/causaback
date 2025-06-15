using System.Data;
using CausaViva.DTOs.Distrito;
using Microsoft.Data.SqlClient;

namespace CausaViva.Services.Distrito
{
    public class DistritoService : IDistritoService
    {
        private readonly string _connectionString;

        public DistritoService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<DistritoDTO>> GetDistritoAll()
        {
            var distritos = new List<DistritoDTO>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("dbo.sp_obtenerdistritos", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            distritos.Add(new DistritoDTO
                            {
                                IdDistrito = reader.GetInt32(reader.GetOrdinal("IdDistrito")), 
                                NombreDistrito = reader.GetString(reader.GetOrdinal("NombreDistrito"))
                            });
                        }
                    }
                }
            }

            return distritos;
        }
    }
}
