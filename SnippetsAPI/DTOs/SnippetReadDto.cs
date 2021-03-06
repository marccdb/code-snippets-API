﻿using System.ComponentModel.DataAnnotations;

namespace SnippetsAPI.DTOs
{
    public class SnippetReadDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }

    }
}
