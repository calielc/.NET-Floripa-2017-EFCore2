namespace EFCore.Data {
    public class Photo {
        public int Id { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public People Photographer { get; set; }

        public PhotoGeolocation Geolocation { get; set; }
    }
}