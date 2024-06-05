using System.Text.Json.Serialization;

namespace FiltroApi.Models{
    public class Pet{
        public int Id { get; set; }
        public string? Names { get; set; }
        public string? Specie { get; set; }
        public string? Race { get; set; }
        public DateTime? DateBirth { get; set;}
        public string? Photo { get; set; }
        public int OwnerId { get; set; } 
        public Owner? Owner { get; set; } //Conection to weak table
        
        [JsonIgnore] 
        public List<Quote>? Quote { get; set; } //Conection to strong table

    }
}