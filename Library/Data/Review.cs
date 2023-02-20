using System.ComponentModel.DataAnnotations;

namespace Library.Data
{
    public class Review
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Reviewer { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public Book Book { get; set; }
    }
}
