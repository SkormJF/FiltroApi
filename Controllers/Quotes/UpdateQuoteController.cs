using Microsoft.AspNetCore.Mvc;
using FiltroApi.Models;
using FiltroApi.Services;

namespace FiltroApi.Controllers{
    [ApiController]
    [Route("/api/[controller]")]
    public class UpdateQuoteController : ControllerBase{
        private readonly IQuotesServices _quotesServices;
        public UpdateQuoteController(IQuotesServices quotesServices){
            _quotesServices = quotesServices;
        }

        [HttpPut("{id}")]
        public ActionResult<Quote> Update(string id, [FromBody]Quote quote){
            var result =  _quotesServices.Update(id, quote);
            if(result == null){
                return NotFound($"This quote already exists");
            }
            return Ok(result);
        }
    }
}