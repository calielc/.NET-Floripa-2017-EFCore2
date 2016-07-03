using System.Collections.Generic;

namespace EFCore.App.Database
{
    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double ABV { get; set; }
        public double? IBU { get; set; }

        public Craft Craft { get; set; }
    }
}