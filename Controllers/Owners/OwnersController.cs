using Microsoft.AspNetCore.Mvc;
using FiltroApi.Models;
using FiltroApi.Services;

namespace FiltroApi.Controllers{
    [ApiController]
    [Route("/api/[controller]")]
    public class OwnersController : ControllerBase{
        private readonly IOwnersServices _ownersServices;
        public OwnersController(IOwnersServices ownersServices){
            _ownersServices = ownersServices;
        }

        [HttpGet]
        public IEnumerable<Owner> GetOwners(){
            return _ownersServices.GetOwners();
        }
        
        [HttpGet("{id}")]
        public ActionResult<Owner> GetOwner(string id){
            var result = _ownersServices.GetOwner(id);
            if(result == null){
                return NotFound($"Didn't find owner with id: {id}, or you typed a wrong value");
            }
            return Ok(result);
        }

        [HttpGet("/owner/{id}/pets")]
        public ActionResult<Owner> GetOwnerPets(string id){
            var owner = _ownersServices.GetOwnerPets(id);
            if(owner == null){
                return NotFound($"Didn't find owner with id: {id}, or you typed a wrong value");
            }
            var result = owner.Pet.Select(x => new{
                x.Names,
                x.Specie,
                x.Race,
            });

            return Ok(result);
        }
    }
}
