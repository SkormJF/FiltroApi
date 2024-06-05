using FiltroApi.Models;

namespace FiltroApi.Services{
    public interface IVetsServices{
        IEnumerable<Vet> GetVets();
        Vet? GetVet(string id);
    }
}