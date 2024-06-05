using FiltroApi.Models;

namespace FiltroApi.Services{
    public interface IPetsServices{
        IEnumerable<Pet>? GetPets();
        Pet? GetPet(string id);
        Pet? Create(Pet pet);
        Pet? Update(string id, Pet pet);

        Task<Pet> GetPetOwner(int? petId);

        IEnumerable<Pet> GetPetsByBirthday(DateTime date);
        
    }
}