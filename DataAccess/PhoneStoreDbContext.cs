using DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class PhoneStoreDbContext(DbContextOptions<PhoneStoreDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            Phone[] phone = new Phone[3];
            phone[0] = new Phone();
            phone[1] = new Phone();
            phone[2] = new Phone();

            phone[0].Id = 1;
            phone[0].ManufacturerId = 2;
            phone[0].Series = "A25";
            phone[0].Price = 155;
            phone[0].Description = "low cost phone";
            phone[0].CategoryId = 1;

            phone[1].Id = 2;
            phone[1].ManufacturerId = 2;
            phone[1].Series = "A35";
            phone[1].Price = 255;
            phone[1].Description = "cool phone";
            phone[1].CategoryId = 1;

            phone[2].Id = 3;
            phone[2].ManufacturerId = 1;
            phone[2].Series = "15";
            phone[2].Price = 300;
            phone[2].Description = "best phone";
            phone[2].CategoryId = 1;


            Category[] category = new Category[2];
            category[0] = new Category();
            category[1] = new Category();

            category[0].Id = 1;
            category[0].Title = "Smartphone";

            category[1].Id = 2;
            category[1].Title = "Buttonphone";


            Manufacturer[] manufacturer = new Manufacturer[2];
            manufacturer[0] = new Manufacturer();
            manufacturer[1] = new Manufacturer();

            manufacturer[0].Id = 1;
            manufacturer[0].Title = "iPhone";

            manufacturer[1].Id = 2;
            manufacturer[1].Title = "Samsung";


            builder.Entity<Phone>().HasData(phone);
            builder.Entity<Category>().HasData(category);
            builder.Entity<Manufacturer>().HasData(manufacturer);
        }
    }
}
