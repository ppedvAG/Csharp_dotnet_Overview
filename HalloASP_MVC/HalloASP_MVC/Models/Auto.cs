namespace HalloASP_MVC.Models
{
    public class Auto
    {
        public int Id { get; set; }

        public string Modell { get; set; } = string.Empty;
        public string Hersteller { get; set; } = string.Empty;
        public int PS { get; set; }
        public double Gewicht { get; set; }
        public DateTime Baujahr { get; set; }

    }
}
