using Microsoft.AspNetCore.Mvc;
using FiltroApi.Models;
using FiltroApi.Services;

namespace FiltroApi.Controllers{
    [ApiController]
    [Route("/api/[controller]")]
    public class VetsController : ControllerBase{
        private readonly IVetsServices _vetsServices;
        public VetsController(IVetsServices vetsServices){
            _vetsServices = vetsServices;
        }

        [HttpGet]
        public IEnumerable<Vet> GetVets(){
            return _vetsServices.GetVets();
        }
        
        [HttpGet("{id}")]
        public ActionResult<Vet> GetVet(string id){
            var result = _vetsServices.GetVet(id);
            if(result == null){
                return NotFound($"Didn't find vet with id: {id}, or you typed a wrong value");
            }
            return Ok(result);
        }
    }
}