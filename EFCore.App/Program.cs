using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCore.App.Database;
using Microsoft.EntityFrameworkCore;

namespace EFCore.App
{
    class Program
    {
        static void Main(string[] args)
        {
            //InsertSchornstein();
            //InsertBrooklyn();

            //SaveToast();
            SaveToastComTransacao();
        }

        private static void SaveToastComTransacao()
        {
            using (var context = new BeerCraftDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var beer = context.Beers.Single(x => x.Name == "Brooklyn Lager");

                    var toast = new Toast
                    {
                        Beer = beer,
                        Nota = 2,
                        Description = "Errei",
                        DateTime = DateTime.UtcNow,
                    };
                    context.Add(toast);

                    context.SaveChanges();

                    transaction.Rollback();
                }
            }

            using (var context = new BeerCraftDbContext())
            {
                var toasts = context.Set<Toast>().Include(toast => toast.Beer).ThenInclude(beer => beer.Craft).ToArray();
                foreach (var toast in toasts)
                {
                    Console.WriteLine($"{toast.Beer?.Craft?.Name} - {toast.Beer?.Name} - {toast.Nota}");
                }
            }
        }

        private static void SaveToast()
        {
            using (var context = new BeerCraftDbContext())
            {
                var beer = context.Beers
                    .Include(x => x.Craft)
                    .Single(x => x.Name == "Weiss" && x.Craft.Name == "Cervejaria Schornstein");

                var toast = new Toast
                {
                    Beer = beer,
                    Nota = 4,
                    Description = "Acompanha um bom frango",
                    DateTime = DateTime.UtcNow,
                };
                context.Add(toast);

                context.SaveChanges();
            }
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
