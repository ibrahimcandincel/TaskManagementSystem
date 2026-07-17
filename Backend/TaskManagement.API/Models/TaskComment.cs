using System;
using System.Collections.Generic;

namespace TaskManagement.API.Models
{
    public class TaskComment
    {
        public Guid Id { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Guid TaskId { get; set; }
        public TaskItem? Task { get; set; }

        public Guid UserId { get; set; }
        public User? User { get; set; }
    }
}