using TaskManagement.API.DTOs;

namespace TaskManagement.API.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategoriesByUserIdAsync(Guid userId);
        Task<CategoryDto> GetCategoryByIdAsync(Guid id, Guid userId);
        Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto createCategoryDto, Guid userId);
        Task<CategoryDto> UpdateCategoryAsync(Guid id, UpdateCategoryDto updateCategoryDto, Guid userId);
        Task DeleteCategoryAsync(Guid id, Guid userId);
    }
}