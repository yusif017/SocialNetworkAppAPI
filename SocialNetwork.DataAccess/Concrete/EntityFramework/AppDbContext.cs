using Microsoft.EntityFrameworkCore;
using SocialNetwork.Core.Configuration;
using SocialNetwork.Core.Entities.Concrete;
using SocialNetwork.Entities.Concrete;

namespace SocialNetwork.DataAccess.Concrete.EntityFramework
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<FriendList> FriendLists { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FriendList>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<FriendList>()
                .HasOne(x => x.User)
                .WithMany(x => x.FriendLists)
                .HasForeignKey(x => x.FriendId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reaction>()
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
