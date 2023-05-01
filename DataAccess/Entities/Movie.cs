namespace Dashboard.DataAccess.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set;}
        public string TrailerUrl { get; set; }
    }
}
