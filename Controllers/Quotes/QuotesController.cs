using Microsoft.AspNetCore.Mvc;
using FiltroApi.Models;
using FiltroApi.Services;

namespace FiltroApi.Controllers{
    [ApiController]
    [Route("/api/[controller]")]
    public class QuotesController : ControllerBase{
        private readonly IQuotesServices _quotesServices;
        public QuotesController(IQuotesServices quotesServices){
            _quotesServices = quotesServices;
        }

        [HttpGet]
        public IEnumerable<Quote> GetQuotes(){
            return _quotesServices.GetQuotes();
        }
        
        [HttpGet("{id}")]
        public ActionResult<Quote> GetQuote(string id){
            var result = _quotesServices.GetQuote(id);
            if(result == null){
                return NotFound($"Didn't find quote with id: {id}, or you typed a wrong value");
            }
            return Ok(result);
        }

        [HttpGet("/date/{date}")]
        public IEnumerable<Quote> GetQuotesByDate(DateTime date){
            return _quotesServices.GetQuotesByDate(date);
        }

        [HttpGet("/quotes/{id}/vets")]
        public IEnumerable<Quote> GetVetQuotes(string id){
            return _quotesServices.GetVetQuotes(id);
        }
    }
}