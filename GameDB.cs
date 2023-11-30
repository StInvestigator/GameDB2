using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDB2
{
    internal class GameDB
    {
        public class GameContext : DbContext
        {
            public string connectionString = @"Data Source=DESKTOP-OF66R01\SQLEXPRESS;Initial Catalog=GamesDB;Integrated Security=True";
            public DbSet<Game> Games { set; get; }
            public DbSet<Creator> Creators { set; get; }
            public DbSet<Style> Styles { set; get; }
            public GameContext()
            {
                Database.EnsureCreated();
            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
