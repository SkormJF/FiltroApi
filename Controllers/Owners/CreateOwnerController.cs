using Microsoft.AspNetCore.Mvc;
using FiltroApi.Models;
using FiltroApi.Services;

namespace FiltroApi.Controllers{
    [ApiController]
    [Route("/api/[controller]")]
    public class CreateOwnerController: ControllerBase{
        private readonly IOwnersServices _ownersService;
        public CreateOwnerController(IOwnersServices ownersService){
            _ownersService = ownersService;
        }

        [HttpPost]
        public ActionResult<Owner> Create([FromBody] Owner owner){
            var result = _ownersService.Create(owner);
            if(result == null){
                return NotFound($"This owner already exists");
            }
            return Ok(result); //I KNOW THAT I HAVE TO RETURN CREATED(uri, result) I FORGET HOW TO CREATE URI
        }

    }
}