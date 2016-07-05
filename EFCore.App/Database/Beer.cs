using System.ComponentModel.DataAnnotations;

namespace EFCore.App.Database
{
    public class Beer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public double ABV { get; set; }

        public double? IBU { get; set; }

        public string Logo { get; set; }

        public Craft Craft { get; set; }
    }
}