
using PhoneBook.Models;
using Microsoft.EntityFrameworkCore;

namespace 	PhoneBook.Data{

    public class PhoneBookContext:DbContext{
    
        public PhoneBookContext(DbContextOptions<PhoneBookContext> options) : base(options)
        {
        }
    public DbSet<Person> Persons { get; set;}
    public DbSet<Phone> Phones { get; set; }
    public DbSet<Email> Emails { get; set; }

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<Phone>()
            .HasOne(p => p.Person)
            .WithMany(b => b.Phone).HasForeignKey(p => p.PersonPhone);

             modelBuilder.Entity<Email>()
            .HasOne(p => p.Person)
            .WithMany(b => b.Email).HasForeignKey(p => p.PersonEmile);

        }
        #endregion
    
    }


  
        
}
