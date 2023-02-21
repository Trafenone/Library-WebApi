using System.ComponentModel.DataAnnotations;

namespace Library.Models.DTO
{
    public class ReviewDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(100, MinimumLength = 3,
        ErrorMessage = "Message should be minimum 3 characters and maximum of 100 characters")]
        public string Message { get; set; }
        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(30, MinimumLength = 3,
        ErrorMessage = "Reviewer should be minimum 3 characters and maximum of 30 characters")]
        public string Reviewer { get; set; }
    }
}
