using Microsoft.EntityFrameworkCore;
using FiltroApi.Models;
using FiltroApi.Data;

namespace FiltroApi.Services{
    public class OwnersServices: IOwnersServices{
        private readonly ApiContext _context;

        public OwnersServices(ApiContext context){
            _context = context;
        }

        public IEnumerable<Owner> GetOwners(){
            return _context.Owners.ToList();
        }

        public Owner? GetOwner(string id){
            if(!int.TryParse(id, out int parseId)){
                return null;
            }
            return _context.Owners.Find(parseId);
        }

        public Owner? Create(Owner owner){
            var id = _context.Owners.Find(owner.Id);
            if(id != null){
                return null;
            }
            _context.Owners.Add(owner);
            _context.SaveChanges();
            return owner;
        }

        public Owner? Update(string id, Owner owner){
            if(!int.TryParse(id, out int parseId)){
                return null;
            }
            var ownerToUpdate = _context.Owners.Find(parseId);
            if(ownerToUpdate == null){
                return null;
            }

            ownerToUpdate.Names = owner.Names;
            ownerToUpdate.LastNames = owner.LastNames;
            ownerToUpdate.Email = owner.Email;  
            ownerToUpdate.Phone = owner.Phone;
            ownerToUpdate.Address = owner.Address;

            _context.Owners.Update(ownerToUpdate);
            _context.SaveChanges();
            return ownerToUpdate;
        }

        public async Task<Owner> GetOwnerEmail(int ownerId){
            return await _context.Owners.FirstOrDefaultAsync(o => o.Id == ownerId);
        }

        public Owner? GetOwnerPets(string id){
            if(!int.TryParse(id, out int parseId)){
                return null;
            }
            var pets = _context.Owners
                .Include(x => x.Pet)
                .Where(p => p.Pet.Any(p => p.Id == parseId))
                .FirstOrDefault();
            
            return pets;
        }
    }
}