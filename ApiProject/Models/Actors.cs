using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProject.Models
{
    public class Actors
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Surname { get; set; }
        public DateTime Birthday { get; set; }
    }
}
