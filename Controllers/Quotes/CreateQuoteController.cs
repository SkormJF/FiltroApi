using Microsoft.AspNetCore.Mvc;
using FiltroApi.Models;
using FiltroApi.Services;

namespace FiltroApi.Controllers{
    [ApiController]
    [Route("/api/[controller]")]
    public class CreateQuoteController : ControllerBase{
        private readonly IQuotesServices _quotesServices;
        public CreateQuoteController(IQuotesServices quotesServices){
            _quotesServices = quotesServices;
        }

        [HttpPost]
        public async Task<ActionResult<Quote>> Create([FromBody]Quote quote){
            var result = await _quotesServices.Create(quote);
            if(result == null){
                return NotFound($"This quote already exists");
            }
            return Ok(result);
        }
    }
}