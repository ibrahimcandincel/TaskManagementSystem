using System;
using System.Collections.Generic;
using TaskManagement.API.Models.Enums;

namespace TaskManagement.API.Models
{
    public class TaskItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? DueDate { get; set; }
        public DateTime? CompletedAt { get; set; }
        
        public Priority Priority { get; set; } = Priority.Low;
        public Status Status { get; set; } = Status.Pending;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public Guid UserId { get; set; }
        public User? User { get; set; } 

        public Guid? CategoryId { get; set; }
        public Category? Category { get; set; }

        public ICollection<TaskComment> Comments { get; set; } = new List<TaskComment>();
        public ICollection<TaskAttachment> Attachments { get; set; } = new List<TaskAttachment>();
    }
}