using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Torito.Data.Persistance.DataModels;
using Torito.Data.Persistance.DataModels.Gmaps;
using Torito.Models.Utils.Tools;

namespace Torito.Data.Persistance.Context
{
    public class ToritoContext : DbContext
    {
        private readonly string _connectionString;
        public ToritoContext(DbContextOptions<ToritoContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }
        internal DbSet<TweetDbo> Tweets { get; set; }
        internal DbSet<EntityDbo> Entities { get; set; }
        internal DbSet<AnnotationDbo> Annotations { get; set; }
        internal DbSet<HashtagDbo> Hastags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TweetDbo>()
                .Property(t => t.LastUpdated)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<TweetDbo>()
                .Property(t => t.InsertedAt)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<AddressComponentDbo>()
                .Property(x => x.Types)
                .HasConversion(
                    x => JsonSerializer.Serialize(x, default),
                    x => JsonSerializer.Deserialize<List<string>>(x, default));

            modelBuilder.Entity<ResultDbo>()
                .Property(x => x.Types)
                .HasConversion(
                    x => JsonSerializer.Serialize(x, default),
                    x => JsonSerializer.Deserialize<List<string>>(x, default));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}
