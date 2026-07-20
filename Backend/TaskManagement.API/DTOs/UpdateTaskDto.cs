using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagement.API.DTOs
{
    public class UpdateTaskDto
    {
        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Due date is required.")]
        public DateTime DueDate { get; set; }

        [Range(1, 5, ErrorMessage = "Priority must be between 1 (Low) and 5 (Critical).")]
        public int Priority { get; set; }

        [Range(0, 3, ErrorMessage = "Status must be between 0 (Pending) and 3 (Cancelled).")]
        public int Status { get; set; }

        public Guid? CategoryId { get; set; }
    }
}