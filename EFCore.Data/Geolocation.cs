namespace EFCore.Data {
    public class Geolocation {
        public decimal? Lat { get; set; }
        public decimal? Long { get; set; }

        public string City { get; set; }
        public string Country { get; set; }
    }
}