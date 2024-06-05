using Microsoft.AspNetCore.Mvc;
using FiltroApi.Models;
using FiltroApi.Services;

namespace FiltroApi.Controllers{
    [ApiController]
    [Route("/api/[controller]")]
    public class PetsController : ControllerBase{
        private readonly IPetsServices _petsServices;
        public PetsController(IPetsServices petsServices){
            _petsServices = petsServices;
        }

        [HttpGet]
        public IEnumerable<Pet> GetPets(){
            return _petsServices.GetPets();
        }
        
        [HttpGet("{id}")]
        public ActionResult<Pet> GetPet(string id){
            var result = _petsServices.GetPet(id);
            if(result == null){
                return NotFound($"Didn't find pet with id: {id}, or you typed a wrong value");
            }
            return Ok(result);
        }

        [HttpGet("/pets/{date}/birthday")]
        public IEnumerable<Pet> GetPetsByBirthday(DateTime date){
            return _petsServices.GetPetsByBirthday(date);
        }

    }
}