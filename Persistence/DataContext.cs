using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
	public class DataContext : DbContext
	{
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCategory> UserCategories { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserCategory>(x => x.HasKey(uc => new { uc.UserId, uc.CategoryId }));

            modelBuilder.Entity<UserCategory>()
                .HasOne(u => u.User)
                .WithMany(c => c.Categories)
                .HasForeignKey(uId => uId.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<UserCategory>()
                .HasOne(s => s.Category)
                .WithMany(u => u.Users)
                .HasForeignKey(cId => cId.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserRole>(x => x.HasKey(ur => new { ur.UserId, ur.RoleId }));

            modelBuilder.Entity<UserRole>()
                .HasOne(u => u.User)
                .WithMany(r => r.Roles)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<UserRole>()
                .HasOne(r => r.Role)
                .WithMany(u => u.Users)
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserSkill>(x => x.HasKey(us => new { us.UserId, us.SkillId }));
            modelBuilder.Entity<UserSkill>()
                .HasOne(u => u.User)
                .WithMany(s => s.Skills)
                .HasForeignKey(us => us.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<UserSkill>()
                .HasOne(s => s.Skill)
                .WithMany(u => u.Users)
                .HasForeignKey(us => us.SkillId)
                .OnDelete(DeleteBehavior.NoAction);
		}
	}
}
