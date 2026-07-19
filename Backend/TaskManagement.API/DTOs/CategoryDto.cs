using System;

namespace TaskManagement.API.DTOs.CategoryDTOs
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public Guid UserId { get; set; }
    }
}