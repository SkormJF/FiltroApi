using Microsoft.AspNetCore.Mvc;
using FiltroApi.Models;
using FiltroApi.Services;

namespace FiltroApi.Controllers{
    [ApiController]
    [Route("/api/[controller]")]
    public class CreatePetController : ControllerBase{
        private readonly IPetsServices _petsServices;
        public CreatePetController(IPetsServices petsServices){
            _petsServices = petsServices;
        }

        [HttpPost]
        public ActionResult<Pet> Create([FromBody] Pet pet){
            var result = _petsServices.Create(pet);
            if(result == null){
                return NotFound($"This pet already exist");
            }
            return Ok(result);
        }       
    }
}