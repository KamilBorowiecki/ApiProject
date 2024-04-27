namespace ApiProject.Models
{
    public class Movies
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Rate { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Category {  get; set; }
        public string Country { get; set; }
        public string Actors { get; set; }
        
    }
}
