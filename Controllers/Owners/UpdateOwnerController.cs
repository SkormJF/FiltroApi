using Microsoft.AspNetCore.Mvc;
using FiltroApi.Models;
using FiltroApi.Services;

namespace FiltroApi.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class UpdateOwnerController : ControllerBase{
        private readonly IOwnersServices _ownersServices;
        public UpdateOwnerController(IOwnersServices ownersServices){
            _ownersServices = ownersServices;
        }

        [HttpPut("{id}")]
        public ActionResult<Owner> Update(string id, [FromBody] Owner owner){
            var result = _ownersServices.Update(id, owner);
            if(result == null){
                return NotFound($"Didn't find id owner: {id} to update, or you typed a wrong data");
            }
            return Ok(result);
        }
    }
}