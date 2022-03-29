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
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<SkillCategory> SkillCategories { get; set; }
        public DbSet<UserCategory> UserCategories { get; set; }
        public DbSet<Mentorship> Mentorships { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserFollowing> UserFollowings { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<TrainerAvailableSessions> TrainerAvailableSessions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserSkill>(x => x.HasKey(us => new { us.UserId, us.  SkillId }));

            modelBuilder.Entity<UserSkill>()
                .HasOne(s => s.User)
                .WithMany(u => u.Skills)
                .HasForeignKey(s => s.UserId)
                // proveriti
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<UserSkill>()
                .HasOne(s => s.Skill)
                .WithMany(u => u.Users)
                .HasForeignKey(s => s.SkillId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserCategory>(x => x.HasKey(uc => new { uc.UserId, uc.CategoryId }));

            modelBuilder.Entity<UserCategory>()
                .HasOne(c => c.User)
                .WithMany(u => u.Categories)
                .HasForeignKey(uc => uc.UserId)
                // proveriti
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<UserCategory>()
                .HasOne(c => c.Category)
                .WithMany(u => u.Users)
                .HasForeignKey(uc => uc.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SkillCategory>(x => x.HasKey(sc => new { sc.SkillId, sc.CategoryId }));

            modelBuilder.Entity<SkillCategory>()
                .HasOne(s => s.Skill)
                .WithMany(c => c.Categories)
                .HasForeignKey(sc => sc.SkillId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<SkillCategory>()
                .HasOne(c => c.Category)
                .WithMany(s => s.Skills)
                .HasForeignKey(cs => cs.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Review>(x => x.HasKey(rw => new { rw.ClientId, rw.TrainerId }));

            modelBuilder.Entity<Review>()
                .HasOne(c => c.Client)
                .WithMany(t => t.TrainerReviews)
                .HasForeignKey(c => c.ClientId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Review>()
                .HasOne(t => t.Trainer)
                .WithMany(c => c.ClientReviews)
                .HasForeignKey(t => t.TrainerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Mentorship>(x => x.HasKey(ct => new { ct.ClientId, ct.TrainerId }));

            modelBuilder.Entity<Mentorship>()
                .HasOne(c => c.Client)
                .WithMany(t => t.Trainers)
                .HasForeignKey(c => c.ClientId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Mentorship>()
                .HasOne(c => c.Trainer)
                .WithMany(t => t.Clients)
                .HasForeignKey(c => c.TrainerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Message>(x => x.HasKey(me => new { me.ClientId, me.TrainerId }));

            modelBuilder.Entity<Message>()
                .HasOne(me => me.Client)
                .WithMany(t => t.TrainerMessages)
                .HasForeignKey(c => c.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Message>()
                .HasOne(me => me.Trainer)
                .WithMany(c => c.ClientMessages)
                .HasForeignKey(t => t.TrainerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserFollowing>(x => x.HasKey(uf => new { uf.ClientId, uf.TrainerId }));

            modelBuilder.Entity<UserFollowing>()
                .HasOne(uf => uf.Client)
                .WithMany(u => u.TrainerFollowings)
                .HasForeignKey(c => c.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<UserFollowing>()
                .HasOne(uf => uf.Trainer)
                .WithMany(c => c.ClientFollowings)
                .HasForeignKey(t => t.TrainerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Schedule>(x => x.HasKey(s => new { s.ClientId, s.TrainerId }));

            modelBuilder.Entity<Schedule>()
                .HasOne(cl => cl.Client)
                .WithMany(tr => tr.TrainersSchedule)
                .HasForeignKey(c => c.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Schedule>()
                .HasOne(tr => tr.Trainer)
                .WithMany(cl => cl.ClientsSchedule)
                .HasForeignKey(t => t.TrainerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TrainerAvailableSessions>(x => x.HasKey(t => new { t.TrainerId, t.SessionId }));

            modelBuilder.Entity<TrainerAvailableSessions>()
                .HasOne(t => t.Trainer)
                .WithMany(s => s.Sessions)
                .HasForeignKey(t => t.TrainerId);
            modelBuilder.Entity<TrainerAvailableSessions>()
                .HasOne(s => s.Session)
                .WithMany(t => t.Trainers)
                .HasForeignKey(t => t.TrainerId);


        }

    }
}
