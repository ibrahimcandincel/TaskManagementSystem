using System;

namespace TaskManagement.API.DTOs.TaskDTOs
{
    public class TaskItemDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public int Priority { get; set; } 
        public int Status { get; set; } 
        public DateTime CreatedAt { get; set; }
        public Guid UserId { get; set; }
        public Guid? CategoryId { get; set; }
    }
}