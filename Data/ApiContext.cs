using FiltroApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FiltroApi.Data{
    public class ApiContext : DbContext{
        public ApiContext(DbContextOptions<ApiContext> options):base(options){}

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Vet> Vets { get; set; }
    }
}