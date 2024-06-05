using Microsoft.EntityFrameworkCore;
using FiltroApi.Models;
using FiltroApi.Data;

namespace FiltroApi.Services{
    public class VetsServices: IVetsServices{
        private readonly ApiContext _context;

        public VetsServices(ApiContext context){
            _context = context;
        }

        public IEnumerable<Vet> GetVets(){
            return _context.Vets.ToList();
        }

        public Vet? GetVet(string id){
            if(!int.TryParse(id, out int parseId)){
                return null;
            }
            return _context.Vets.Find(parseId);
        }

    }
}