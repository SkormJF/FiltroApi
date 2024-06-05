using System.Text.Json.Serialization;

namespace FiltroApi.Models{
    public class Vet{
        public int Id { get; set; }
        public string? Names { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }

        [JsonIgnore]
        public List<Quote>? Quote { get; set; } //Conection to strong table
    }
}