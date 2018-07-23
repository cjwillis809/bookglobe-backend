using System.ComponentModel.DataAnnotations;

namespace bookglobe_backend.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        [Required]
        [StringLength(255)]
        public string Author { get; set; }
        public string CoverImage { get; set; }
        public int PageLength { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }
    }
}