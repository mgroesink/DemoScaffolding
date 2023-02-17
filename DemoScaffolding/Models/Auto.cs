namespace DemoScaffolding.Models
{
    public class Auto
    {
        public int ID { get; set; }
        public string Kenteken { get; set; }
        public string Merk { get; set; }
        public List<Eigenaar> Eigenaren { get; set; } = new List<Eigenaar>();
    }
}
