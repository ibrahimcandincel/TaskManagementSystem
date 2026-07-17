using System;
using Microsoft.EntityFrameworkCore;
using TaskManagement.API.Models;

namespace TaskManagement.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<TaskAttachment> TaskAttachments { get; set; }
        public DbSet<TaskComment> TaskComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(u => u.Username).IsUnique();
                entity.Property(u => u.Username).HasMaxLength(50).IsRequired();
                entity.HasIndex(u => u.Email).IsUnique();
                entity.Property(u => u.Email).HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<TaskItem>(entity =>
            {
                entity.HasOne(t => t.User)
                      .WithMany(u => u.Tasks)
                      .HasForeignKey(t => t.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(t => t.Category)
                      .WithMany(c => c.Tasks)
                      .HasForeignKey(t => t.CategoryId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasOne(c => c.User)
                      .WithMany(u => u.Categories)
                      .HasForeignKey(c => c.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });


            var demoUserId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = demoUserId,
                Username = "demouser",
                Email = "demo@taskmanagement.com",
                PasswordHash = "hashed_password_placeholder", // İleride gerçek hash ile değiştireceğiz
                FirstName = "Demo",
                LastName = "Kullanıcı",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsActive = true
            });
        }
    }
}