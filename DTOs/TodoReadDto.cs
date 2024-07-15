using System;
using System.ComponentModel.DataAnnotations;

namespace TodoApi2.DTOs
{
    public class TodoReadDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsDone { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}