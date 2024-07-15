using System;
using System.ComponentModel.DataAnnotations;

namespace TodoApi2.DTOs
{
    public class TodoUpdateDto
    {
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public bool IsDone { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}