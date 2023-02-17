using System.ComponentModel.DataAnnotations;

namespace DemoScaffolding.Models
{
    public class Eigenaar
    {
        private string? postcode;

        public int ID { get; set; }
        [StringLength(100)]
        public string Naam { get; set; } = string.Empty;
        [StringLength(6),RegularExpression("[1-9][0-9]{3}[A-Za-z]{2}")]
        public string? Postcode { get => postcode; set => postcode = value.ToUpper(); }
        [StringLength(75)] 
        public string? Adres { get; set; }
        [StringLength(75)] 
        public string? Plaats { get; set; }
        public List<Auto> Autos { get; set; } = new List<Auto>();
    }
}
