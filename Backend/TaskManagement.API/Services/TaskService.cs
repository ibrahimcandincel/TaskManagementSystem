using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskManagement.API.Data;
using TaskManagement.API.DTOs;
using TaskManagement.API.Models;
using TaskManagement.API.Models.Enums;

namespace TaskManagement.API.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TaskService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskItemDto>> GetTasksByUserIdAsync(Guid userId)
        {
            var tasks = await _context.Tasks
                .Include(t => t.Category)
                .Where(t => t.UserId == userId)
                .ToListAsync();

            return _mapper.Map<IEnumerable<TaskItemDto>>(tasks);
        }

        public async Task<TaskItemDto> GetTaskByIdAsync(Guid id, Guid userId)
        {
            var task = await _context.Tasks
                .Include(t => t.Category)
                .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);

            if (task == null)
            {
                throw new Exception("Task not found or you do not have permission to access it.");
            }

            return _mapper.Map<TaskItemDto>(task);
        }

        public async Task<TaskItemDto> CreateTaskAsync(CreateTaskDto createTaskDto, Guid userId)
        {
            if (createTaskDto.CategoryId.HasValue)
            {
                var categoryExists = await _context.Categories
                    .AnyAsync(c => c.Id == createTaskDto.CategoryId.Value && c.UserId == userId);
                    
                if (!categoryExists)
                {
                    throw new Exception("Invalid category provided.");
                }
            }

            var task = _mapper.Map<TaskItem>(createTaskDto);
            task.UserId = userId;
            task.CreatedAt = DateTime.UtcNow;
            task.UpdatedAt = DateTime.UtcNow;
            task.Status = Status.Pending;

            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();

            return _mapper.Map<TaskItemDto>(task);
        }

        public async Task<TaskItemDto> UpdateTaskAsync(Guid id, UpdateTaskDto updateTaskDto, Guid userId)
        {
            var task = await _context.Tasks
                .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);

            if (task == null)
            {
                throw new Exception("Task not found or unauthorized to update.");
            }

            if (updateTaskDto.CategoryId.HasValue)
            {
                var categoryExists = await _context.Categories
                    .AnyAsync(c => c.Id == updateTaskDto.CategoryId.Value && c.UserId == userId);
                    
                if (!categoryExists)
                {
                    throw new Exception("Invalid category provided.");
                }
            }

            _mapper.Map(updateTaskDto, task);
            task.UpdatedAt = DateTime.UtcNow;
            
            if (task.Status == Status.Completed && task.CompletedAt == null)
            {
                task.CompletedAt = DateTime.UtcNow;
            }
            else if (task.Status != Status.Completed)
            {
                task.CompletedAt = null;
            }

            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();

            return _mapper.Map<TaskItemDto>(task);
        }

        public async Task DeleteTaskAsync(Guid id, Guid userId)
        {
            var task = await _context.Tasks
                .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);

            if (task == null)
            {
                throw new Exception("Task not found or unauthorized to delete.");
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}