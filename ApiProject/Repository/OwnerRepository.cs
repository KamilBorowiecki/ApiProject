using ApiProject.Data;
using ApiProject.Interfaces;
using ApiProject.Models;

namespace ApiProject.Repository
{
    public class OwnerRepository : IOwnerInterfaces
    {
        private readonly DataContext _context;
        public OwnerRepository(DataContext dataContext)
        {
            this._context = dataContext;
        }

        public Owner GetOwner(int id)
        {
            return _context.Owners.Where(b => b.Id == id).FirstOrDefault();
        }

        public Owner GetOwnerByName(string name)
        {
            return _context.Owners.Where(b => b.Name == name).FirstOrDefault();
        }

        public ICollection<Owner> GetOwners()
        {
            return _context.Owners.OrderBy(b => b.Id).ToList();
        }

        public bool HasOwner(int ownerID)
        {
            return _context.Owners.Any(b => b.Id == ownerID);
        }
        public ICollection<string> getBooksByOwner(int ownerId)
        {
            return _context.Books.Where(p => p.OwnerId == ownerId).Select(b=>b.Title).ToList();
        }
    }
}
