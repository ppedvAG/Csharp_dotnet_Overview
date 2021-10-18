namespace HalloWebAPI.Model
{
    public class Auto
    {
        public int Id { get; set; }
        public string Hersteller { get; set; }
        public string Modell { get; set; }
        public int PS { get; set; }

        public DateTime Baujahr { get; set; }
    }
}
