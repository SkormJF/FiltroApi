using FiltroApi.Models;

namespace FiltroApi.Services{
    public interface IQuotesServices{
        IEnumerable<Quote>? GetQuotes();
        Quote? GetQuote(string id);
        Task<Quote> Create(Quote quote);
        Quote? Update(string id, Quote quote);

        IEnumerable<Quote> GetQuotesByDate(DateTime date);

        IEnumerable<Quote> GetVetQuotes(string id);

    }
}