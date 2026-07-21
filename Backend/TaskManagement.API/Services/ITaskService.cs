using TaskManagement.API.DTOs;

namespace TaskManagement.API.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskItemDto>> GetTasksByUserIdAsync(Guid userId);
        Task<TaskItemDto> GetTaskByIdAsync(Guid id, Guid userId);
        Task<TaskItemDto> CreateTaskAsync(CreateTaskDto createTaskDto, Guid userId);
        Task<TaskItemDto> UpdateTaskAsync(Guid id, UpdateTaskDto updateTaskDto, Guid userId);
        Task DeleteTaskAsync(Guid id, Guid userId);
    }
}