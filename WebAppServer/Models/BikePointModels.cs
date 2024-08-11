namespace WebAppServer.Models
{
    public class Place
    {
        public string id { get; set; }
        public string url { get; set; }
        public string commonName { get; set; }
        public double distance { get; set; }
        public string placeType { get; set; }
        public List<AdditionalProperty> additionalProperties { get; set; }
        public List<Place> children { get; set; }
        public string[] childrenUrls { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }

    }

    public class AdditionalProperty
    {
        public string category { get; set; }
        public string key { get; set; }
        public string sourceSystemKey { get; set; }
        public string value { get; set; }
        public string modified { get; set; }
    }

}