using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCore.App.Database;

namespace EFCore.App
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertSchornstein();
            InsertBrooklyn();
        }

        private static void InsertBrooklyn()
        {
            using (var context = new BeerCraftDbContext())
            {
                context.Crafts.Add(new Craft
                {
                    Name = "Brooklyn Brewery",
                    Beers = new List<Beer>
                    {
                        new Beer
                        {
                            Name = "Brooklyn Lager",
                            ABV = 5.2,
                            IBU = 33,
                        },
                        new Beer
                        {
                            Name = "Brooklyn East IPA",
                            ABV = 6.9,
                            IBU = 47,
                        },
                    }
                });
                context.SaveChanges();
            }

        }

        private static void InsertSchornstein()
        {
            using (var context = new BeerCraftDbContext())
            {
                var craft = new Craft
                {
                    Name = "Cervejaria Schornstein"
                };
                context.Crafts.Add(craft);

                context.Beers.Add(new Beer
                {
                    Name = "IPA",
                    ABV = 6.5,
                    IBU = 45,
                    Craft = craft,
                });
                context.Beers.Add(new Beer
                {
                    Name = "Weiss",
                    ABV = 5,
                    Craft = craft,
                });
                context.Beers.Add(new Beer
                {
                    Name = "Pilsen",
                    ABV = 4.5,
                    Craft = craft,
                });

                context.SaveChanges();

            }
        }
    }
}
