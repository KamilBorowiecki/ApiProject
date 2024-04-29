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
            if (dataContext.Owners.Any())
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
                        Name = "Michal Owcarzak",
                        Books = new List<Book>()
                        {
                            new Book(){ Title = "Powojnie"},
                            new Book(){ Title = "Regila 5 sekund" }
                        }
                    },
                    new Owner()
                    {
                        Name = "Kamil Boro",
                        Books = new List<Book>()
                        {
                            new Book(){ Title = "Teoria ukladow Cyfrowych"},
                            new Book(){ Title = "Jak stracilem 1mln" }
                        }
                    }
                };
                dataContext.Owners.AddRange(owners);
                dataContext.SaveChanges();
            }
        }
    }
}
