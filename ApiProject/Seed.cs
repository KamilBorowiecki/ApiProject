using ApiProject.Data;
using ApiProject.Models;

namespace ApiProject
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.Owners.Any())
            {
                var owners = new List<Owner>()
                {
                    new Owner()
                    {
                        Name = "Jan Kowalski",
                        Books = new List<Book>()
                        {
                            new Book(){ Title = "Czarny Labedz"},
                            new Book(){ Title = "Wiedzmin" }
                        }
                    },
                    new Owner()
                    {
                        Name = "Marek Stachurski",
                        Books = new List<Book>()
                        {
                            new Book(){ Title = "Czarny Labedz"},
                            new Book(){ Title = "Jak stracilem 1mln" },
                            new Book(){ Title = "Powojnie" }
                        }
                    }
                };
                dataContext.Owners.AddRange(owners);
                dataContext.SaveChanges();
            }
        }
    }
}
