using System;

namespace TaskManagement.API.DTOs.TaskDTOs
{
    public class TaskFilterDto
    {
        public string? SearchTerm { get; set; }
        public int? Status { get; set; }
        public int? Priority { get; set; }
        public Guid? CategoryId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}