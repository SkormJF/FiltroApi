using FiltroApi.Models;

namespace FiltroApi.Services{
    public interface IOwnersServices{
        IEnumerable<Owner> GetOwners();
        Owner? GetOwner(string id);
        Owner? Create(Owner owner);
        Owner? Update(string id, Owner owner);

        Task<Owner> GetOwnerEmail(int ownerId);

        Owner? GetOwnerPets(string id);

    }
}