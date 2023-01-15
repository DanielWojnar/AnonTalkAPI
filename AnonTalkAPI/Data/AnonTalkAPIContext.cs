using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using AnonTalkAPI.Models;

namespace AnonTalkAPI.Data
{
    public class AnonTalkAPIContext : DbContext
    {
        public AnonTalkAPIContext(DbContextOptions<AnonTalkAPIContext> options) : base(options)
        {
        }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Board>().HasMany(x => x.Posts).WithOne(x => x.Board);
            modelBuilder.Entity<Post>().HasOne(x => x.Board).WithMany(x => x.Posts);
            modelBuilder.Entity<Post>().HasMany(x => x.Comments).WithOne(x => x.Post);
            modelBuilder.Entity<Comment>().HasOne(x => x.Post).WithMany(x => x.Comments);
        }
    }

}
