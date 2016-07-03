using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCore.App.Database
{
    public class Craft
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Logo { get; set; }

        public List<Beer> Beers { get; set; }
    }
}