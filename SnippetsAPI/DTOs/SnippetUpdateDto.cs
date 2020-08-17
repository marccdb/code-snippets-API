using System.ComponentModel.DataAnnotations;


namespace SnippetsAPI.DTOs
{
    public class SnippetUpdateDto
    {

        [Required]
        public string HowTo { get; set; }

        [Required]
        public string Line { get; set; }

        [Required]
        public string Platform { get; set; }
    }
}
