using System.ComponentModel.DataAnnotations;

namespace Library.Models.DTO
{
    public class RatingDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} is Required")]
        [Range(1,5, ErrorMessage = "Score should be between 1 and 5")]
        public int Score { get; set; }
    }
}
