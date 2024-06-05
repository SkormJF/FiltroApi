using System.Text.Json.Serialization;

namespace FiltroApi.Models{
    public class Quote{
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public int? PetId { get; set; }
        public Pet? Pet { get; set; }//Conextion to weak table
        public int VetId { get; set; }
        public Vet? Vet { get; set; }//Conextion to weak table
    }
}