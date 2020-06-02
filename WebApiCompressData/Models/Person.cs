using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiCompressData.Models
{
    [Table("persons")]
    public class Person
    {
        [Key()]
        public int Id { get; set; }

        [Required()]
        [MaxLength(100)]        
        public string Name { get; set; }
    }

    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> context)
            :base(context)
        {
        }

        public DbSet<Person> Person { get; set; }

    }
}
