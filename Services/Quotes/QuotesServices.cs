using Microsoft.EntityFrameworkCore;
using FiltroApi.Models;
using FiltroApi.Data;

namespace FiltroApi.Services{
    public class QuotesServices: IQuotesServices{
        private readonly ApiContext _context;
        private readonly EmailsServices _emailsServices;

        private readonly IPetsServices _petsServices;
        private readonly IOwnersServices _ownersServices;

        public QuotesServices(ApiContext context, EmailsServices emailsServices, IOwnersServices ownersServices, IPetsServices petsServices){
            _petsServices = petsServices;
            _ownersServices = ownersServices;
            _emailsServices = emailsServices;
            _context = context;
        }

        public IEnumerable<Quote> GetQuotes(){
            return _context.Quotes.Include(x => x.Vet).Include(x => x.Pet).ToList();
        }

        public Quote? GetQuote(string id){
            if(!int.TryParse(id, out int parseId)){
                return null;
            }
            return _context.Quotes.Find(parseId);
        }
        
        public async Task<Quote>? Create(Quote quote){
            var id = _context.Quotes.Find(quote.Id);
            if(id!= null){
                return null;
            }
            _context.Quotes.Add(quote);
            await _context.SaveChangesAsync();

            //Get the pet's owner email
            var pet = await _petsServices.GetPetOwner(quote.PetId);
            if(pet ==  null){
                throw new Exception("Could not find the owner");
            }
            var owner = await _ownersServices.GetOwnerEmail(pet.OwnerId);

            //Send the email to the owner with the confirmation quote
            var from = "MS_wNBFEQ@trial-3vz9dle771q4kj50.mlsender.net";
            var fromName ="";
            var to = new List<string>{owner.Email};
            var toName = new List<string>{owner.Names};
            var subject = "New Quote";
            var text =$"Hi {owner.Names}, your quote has been confirm for {quote.Date}";
            var html = $"<p>Hi {owner.Names},</p><br/><p>your quote has been confirm for{quote.Date}</p>";

            await _emailsServices.SendEmailAsync(from, fromName, to, toName, subject, text, html);

            return quote;
        }

        public Quote? Update(string id, Quote quote){
            if(!int.TryParse(id, out int parseId)){
                return null;
            }
            var quoteToUpdate = _context.Quotes.Find(parseId);
            if(quoteToUpdate == null){
                return null;
            }

            quoteToUpdate.Date = quote.Date;
            quoteToUpdate.Description = quote.Description;
            quoteToUpdate.VetId = quote.VetId;  
            quoteToUpdate.PetId = quote.PetId;

            _context.Quotes.Update(quoteToUpdate);
            _context.SaveChanges();
            return quoteToUpdate;
        }

        public IEnumerable<Quote> GetQuotesByDate(DateTime date){
            return _context.Quotes.Where(x => x.Date == date).ToList();
        }

        public IEnumerable<Quote> GetVetQuotes(string id){
            if(!int.TryParse(id, out int parseId)){
                return null;
            }
            return _context.Quotes.Where(x => x.VetId == parseId).ToList();
        }
    }
}