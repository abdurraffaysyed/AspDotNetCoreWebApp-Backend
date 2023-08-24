using Microsoft.EntityFrameworkCore;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebApp.Models
{
    public class Playlist
    {
        [Required]
        public string id { get; set; }
        public string playlistid { get; set; }
        public string userid { get; set; }
        public string videotitle { get; set; }
        public string description { get; set; }
        public string AuthorId { get; set; }
    }
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public AppDbContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Author>().HasMany(auth => auth.playlists).WithOne().HasForeignKey(pl => pl.AuthorId);
            
        }
        public DbSet<Author> author { get; set; }
        public DbSet<Playlist> playlist { get; set; }
    }
}
