using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Mission06_Gifford.Models
{
    public class InputForm
    {
        [Key]
        [Required] //question marks line up with values that can be null and with how the database is set up.
        public int MovieId { get; set; }
        [Required(ErrorMessage = "Sorry, you need to enter a movie title.")] //error validations
        public string Title { get; set; }
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        [Range(1888,int.MaxValue, ErrorMessage = "You must enter a valid year.")]
        public int Year { get; set;  }
        public string? Director { get; set; }
        public string? Rating { get; set; }
        public int Edited { get; set; }
        public string? LentTo { get; set; }
        public int CopiedToPlex { get; set; }
        public string? Notes { get; set; }
    }
}
