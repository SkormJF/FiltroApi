using System.Text.Json.Serialization;

namespace FiltroApi.Models{
    public class Owner{
        public int Id { get; set; }
        public string? Names { get; set; }
        public string? LastNames { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }

        
        public List<Pet>? Pet { get; set; } //Conection to strong table
        
    }
}