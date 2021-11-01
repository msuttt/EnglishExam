using EnglishExam.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnglishExam.Models.Entities;

namespace EnglishExam.Models
{
    public class ContextDatabase : DbContext
    {
        private static bool _created = false;
        public ContextDatabase()
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }
        public DbSet<User> User { get; set; }
        public DbSet<Exam> Exam { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Authority> Authority { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=wired.db");
           // optionsBuilder.UseSqlite("Filename=C:\\db\\wired.db");
            //var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "MyDb.db" };
            //var connectionString = connectionStringBuilder.ToString();
            //var connection = new SqliteConnection(connectionString);

            //optionsBuilder.UseSqlite(connection);
        }
    }
}
