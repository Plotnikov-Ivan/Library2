using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libraby2.Library.DAL.Entities;

namespace Libraby2.Library.DAL.Repositories
{
    public class JournalDataBase : DbContext
    {
        public DbSet<JournalEntity> Journals { get; set; } = null!;

        public JournalDataBase()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=JournalsDB;Username=postgres;Password=stud");
        }

    }
}
