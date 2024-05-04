using ApiProject.Models;

namespace ApiProject.Interfaces
{
    public interface IOwnerInterfaces
    {
        ICollection<Owner> GetOwners();
        Owner GetOwner(int ownerId);
        Owner GetOwnerByName(string name);

        bool HasOwner (int ownerId);

        ICollection<string> getBooksByOwner(int ownerId);
    }
}
