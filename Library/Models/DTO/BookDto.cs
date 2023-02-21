using System.ComponentModel.DataAnnotations;

namespace Library.Models.DTO
{
    public class BookDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(50, MinimumLength = 3,
        ErrorMessage = "Title should be minimum 3 characters and maximum of 50 characters")]
        public string Title { get; set; }
        public string? Cover { get; set; }
        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(255, MinimumLength = 3,
        ErrorMessage = "Content should be minimum 3 characters and maximum of 255 characters")]
        public string Content { get; set; }
        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(50, MinimumLength = 3,
        ErrorMessage = "Genre should be minimum 3 characters and maximum of 50 characters")]
        public string Genre { get; set; }
        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(50, MinimumLength = 3,
        ErrorMessage = "Author should be minimum 3 characters and maximum of 50 characters")]
        public string Author { get; set; }
    }
}
