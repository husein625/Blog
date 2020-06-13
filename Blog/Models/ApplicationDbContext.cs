using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BlogPost> BlogPost { get; set; }
        public DbSet<TagList> TagList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TagList>().HasData(
                new TagList() { TagListId = 1,        
                                 Name = "iOS" }); 
            
            modelBuilder.Entity<TagList>().HasData(
                new TagList() { TagListId = 2,        
                                 Name = "Android" }); 
            
            modelBuilder.Entity<BlogPost>().HasData(
                new BlogPost() { BlogPostId = 3,        
                                 Title = "Augmented Reality iOS Application",
                                 Slug = "augmented-reality-ios-application",
                                 Description = "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.",
                                 Body = "The app is simple to use, and will help you decide on your best furniture fit.",
                                 TagListID = 1,
                                 CreatedAt = DateTime.Now
                });  
            
            modelBuilder.Entity<BlogPost>().HasData(
                new BlogPost() { BlogPostId = 2,        
                                 Title = "Augmented Reality iOS Application-2",
                                 Slug = "augmented-reality-ios-application-2",
                                 Description = "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.",
                                 Body = "The app is simple to use, and will help you decide on your best furniture fit.",
                                 TagListID = 2,
                                 CreatedAt = DateTime.Now
                });
        }

        }

        
}
