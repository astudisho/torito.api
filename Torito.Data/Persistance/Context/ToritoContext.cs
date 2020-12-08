using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torito.Data.Persistance.DataModels;
using Torito.Models.Utils.Tools;

namespace Torito.Data.Persistance.Context
{
    public class ToritoContext : DbContext
    {
        private readonly string _connectionString;
        public ToritoContext(string connectionString = default)
        {
            if(connectionString == default)
            {
                var secretManager = new UserSecretManager();
                _connectionString = secretManager.GetDataConnectionStringApiKey();
            }
            _connectionString = connectionString;
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
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<TweetDbo>()
                .Property(t => t.InsertedAt)
                .ValueGeneratedOnAdd()
                .HasDefaultValue(DateTime.Now);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = default;
            if (_connectionString == default)
            {
                var secretManager = new UserSecretManager();
                connectionString = secretManager.GetDataConnectionStringApiKey();
            }
            optionsBuilder.UseSqlServer(_connectionString ?? connectionString);
        }
    }
}
