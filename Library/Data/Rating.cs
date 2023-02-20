using System.ComponentModel.DataAnnotations;

namespace Library.Data
{
    public class Rating
    {
        public int Id { get; set; }
        public int Score { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public Book? Book { get; set; }
    }
}
