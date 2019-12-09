using AskAMech.Domain.Models;
using AskAMech.Infrastructure.SeedData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AskAMech.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(iul => iul.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey(r => r.Id);
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(r => new { r.RoleId, r.UserId });
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(r => new { r.UserId });
            modelBuilder.Entity<Question>().HasData(QuestionsSeed.GenerateQuestions(15));
        }
        public DbSet<Question> Questions { get; set; }
    }

}
