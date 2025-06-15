using CausaViva.DTOs.Distrito;

namespace CausaViva.Services.Distrito
{
    public interface IDistritoService
    {
        Task<IEnumerable<DistritoDTO>> GetDistritoAll();
    }
}
