using System.ComponentModel.DataAnnotations;
namespace Mission06_Gifford.Models
{
    public class InputForm
    {
        [Key]
        [Required]
        public int movieID { get; set; }
        public string title { get; set; }
        public string category { get; set; }
        public int year { get; set;  }
        public string director { get; set; }
        public string rating { get; set; }
        public bool edited { get; set; }
        public string? lentto { get; set; }
        public string? notes { get; set; }
    }
}
