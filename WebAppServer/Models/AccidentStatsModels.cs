namespace WebAppServer.Models
{
    public class AccidentStatsDetail
    {
        public int id { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public string location { get; set; }
        public string date { get; set; }
        public string severity { get; set; }
        public string borough { get; set; }
        public List<AccidentStatsCasualty> casualities { get; set; } 
        public List<AccidentStatsVehicle> vehicles { get; set; }
    }
    public class AccidentStatsCasualty
    {
        public int age { get; set; }
        public string className { get; set; }
        public string severity { get; set; }
        public string mode { get; set; }
        public string ageBand { get; set; } 
    }
    public class AccidentStatsVehicle
    {
        public string type { get; set; }
    }
}