namespace Kovan.API.Models
{
    public class bike
    {
        public string? bike_id { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public bool is_reserved { get; set; }
        public bool is_disabled { get; set; }
        public string? vehicle_type { get; set; }
        public string? total_bookings { get; set; }
        public string? android { get; set; }
        public string? ios { get; set; }
    }

    public class data
    {
        public List<bike>? bikes { get; set; }
    }
    
    public class kovanItemsModel
    {
        public long lastUpdated { get; set; }
        public int ttl { get; set; }
        public data? data { get; set; }
        public int totalCount { get; set; }
        public bool nextPage { get; set; }
    }

}
