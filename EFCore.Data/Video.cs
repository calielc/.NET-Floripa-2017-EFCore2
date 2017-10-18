using System;

namespace EFCore.Data {
    public class Video {
        public int Id { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }
        public TimeSpan Duration { get; set; }

        public People Camera { get; set; }

        public VideoGeolocation Geolocation { get; set; }
    }
}