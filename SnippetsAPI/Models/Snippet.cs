using System.ComponentModel.DataAnnotations;

namespace SnippetsAPI.Models
{
    public class Snippet
    {
        public int Id { get; set; }
        [Required]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string Platform { get; set; }


    }
}
