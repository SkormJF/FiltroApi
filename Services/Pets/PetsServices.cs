using Microsoft.EntityFrameworkCore;
using FiltroApi.Models;
using FiltroApi.Data;

namespace FiltroApi.Services{
    public class PetsServices: IPetsServices{
        private readonly ApiContext _context;

        public PetsServices(ApiContext context){
            _context = context;
        }

        public IEnumerable<Pet> GetPets(){
            return _context.Pets.Include(x => x.Owner).ToList();
        }

        public Pet? GetPet(string id){
            if(!int.TryParse(id, out int parseId)){
                return null;
            }
            return _context.Pets.Find(parseId);
        }

        public Pet? Create(Pet pet){
            var id = _context.Pets.Find(pet.Id);
            if(id!= null){
                return null;
            }
            _context.Pets.Add(pet);
            _context.SaveChanges();
            return pet;
        }

        public Pet? Update(string id, Pet pet){
            if(!int.TryParse(id, out int parseId)){
                return null;
            }
            var petToUpdate = _context.Pets.Find(parseId);
            if(petToUpdate == null){
                return null;
            }

            petToUpdate.Names = pet.Names;
            petToUpdate.Specie = pet.Specie;
            petToUpdate.Race = pet.Race;  
            petToUpdate.DateBirth = pet.DateBirth;
            petToUpdate.OwnerId = pet.OwnerId;
            petToUpdate.Photo = pet.Photo;

            _context.Pets.Update(petToUpdate);
            _context.SaveChanges();
            return petToUpdate;
        }

        public async Task<Pet> GetPetOwner(int? petId){
            return await _context.Pets.FirstOrDefaultAsync(p => p.Id == petId);
        }

        public IEnumerable<Pet>GetPetsByBirthday(DateTime date){
            return _context.Pets.Where(p => p.DateBirth == date).Include(p => p.Owner).ToList();
        }
    }
}