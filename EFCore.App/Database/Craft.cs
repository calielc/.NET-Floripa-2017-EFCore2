using System.Collections.Generic;

namespace EFCore.App.Database
{
    public class Craft
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Beer> Beers { get; set; }
    }
}