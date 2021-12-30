using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace PhoneBook.DataAccess
{
    public class PhoneBookContext : DbContext
    {
        public DbSet<Abonent> Abonents { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<City> Cities { get; set; }

        public PhoneBookContext(DbContextOptions<PhoneBookContext> options)
        : base(options)
        { 
        
        }
    }
}
