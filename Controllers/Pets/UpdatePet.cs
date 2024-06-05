using Microsoft.AspNetCore.Mvc;
using FiltroApi.Models;
using FiltroApi.Services;

namespace FiltroApi.Controllers{
    [ApiController]
    [Route("/api/[controller]")]
    public class UpdatePetController : ControllerBase{
        private readonly IPetsServices _petsServices;
        public UpdatePetController(IPetsServices petsServices){
            _petsServices = petsServices;
        }

        [HttpPut("{id}")]
        public ActionResult<Pet> Update(string id, [FromBody] Pet pet){
            var result = _petsServices.Update(id, pet);
            if(result == null){
                return NotFound($"This pet already exist");
            }
            return Ok(result);
        }       
    }
}