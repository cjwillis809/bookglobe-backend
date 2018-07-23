namespace bookglobe_backend.Controllers.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string CoverImage { get; set; }
        public int PageLength { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }
    }
}