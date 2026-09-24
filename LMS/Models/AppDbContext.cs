using Microsoft.EntityFrameworkCore;

namespace LMS.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BorrowRecord> BorrowRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasMany(c => c.Books)
                .WithOne(b => b.Category)
                .HasForeignKey(b => b.CategoryId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Member>().HasMany(a => a.BorrowRecords)
                .WithOne(a => a.Member);

            modelBuilder.Entity<Book>().HasMany(a => a.BorrowRecords)
                .WithOne(a => a.Book);

            modelBuilder.Entity<Category>().HasIndex(a => a.Name).IsUnique();

            modelBuilder.Entity<Member>().HasIndex(a => a.Email).IsUnique();

            modelBuilder.Entity<BorrowRecord>().
                Property(a => a.BorrowDate).HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<Book>().
                Property(a => a.Price)
                .HasPrecision(10,2);

            modelBuilder.Entity<Member>().HasData(
                new Member
                {
                    Id = 1,
                    FullName = "Ahmed Hassan",
                    Email = "ahmed.hassan@example.com",
                    PhoneNumber = "01012345678"
                },
                new Member
                {
                    Id = 2,
                    FullName = "Sara Mohamed",
                    Email = "sara.mohamed@example.com",
                    PhoneNumber = "01123456789"
                },
                new Member
                {
                    Id = 3,
                    FullName = "Omar Ali",
                    Email = "omar.ali@example.com",
                    PhoneNumber = "01234567890"
                },
                new Member
                {
                    Id = 4,
                    FullName = "Mariam Ibrahim",
                    Email = "mariam.ibrahim@example.com",
                    PhoneNumber = "01098765432"
                },
                new Member
                {
                    Id = 5,
                    FullName = "Youssef Mahmoud",
                    Email = "youssef.mahmoud@example.com",
                    PhoneNumber = "01187654321"
                }
            );

            modelBuilder.Entity<Book>().HasData(
       new Book
       {
           Id = 1,
           Title = "Clean Code",
           Author = "Robert C. Martin",
           PublishedYear = 2008,
           Price = 35.99m,
           AvailableCopies = 5,
           CategoryId = 1
       },
       new Book
       {
           Id = 2,
           Title = "The Pragmatic Programmer",
           Author = "Andrew Hunt",
           PublishedYear = 1999,
           Price = 42.50m,
           AvailableCopies = 3,
           CategoryId = 1
       },
       new Book
       {
           Id = 3,
           Title = "Introduction to Algorithms",
           Author = "Thomas H. Cormen",
           PublishedYear = 2009,
           Price = 55.00m,
           AvailableCopies = 4,
           CategoryId = 2
       },
       new Book
       {
           Id = 4,
           Title = "Design Patterns",
           Author = "Erich Gamma",
           PublishedYear = 1994,
           Price = 48.75m,
           AvailableCopies = 2,
           CategoryId = 2
       },
       new Book
       {
           Id = 5,
           Title = "The Great Gatsby",
           Author = "F. Scott Fitzgerald",
           PublishedYear = 1925,
           Price = 15.99m,
           AvailableCopies = 6,
           CategoryId = 3
       }
   );


            modelBuilder.Entity<Category>().HasData(
    new Category
    {
        Id = 1,
        Name = "Programming"
    },
    new Category
    {
        Id = 2,
        Name = "Computer Science"
    },
    new Category
    {
        Id = 3,
        Name = "Literature"
    },
    new Category
    {
        Id = 4,
        Name = "History"
    },
    new Category
    {
        Id = 5,
        Name = "Science"
    }
);

            modelBuilder.Entity<BorrowRecord>().HasData(
    new BorrowRecord
    {
        Id = 1,
        BorrowDate = new DateTime(2026, 9, 1),
        ReturnDate = new DateTime(2026, 9, 10),
        MemberId = 1,
        BookId = 1
    },
    new BorrowRecord
    {
        Id = 2,
        BorrowDate = new DateTime(2026, 9, 2),
        ReturnDate = new DateTime(2026, 9, 12),
        MemberId = 2,
        BookId = 3
    },
    new BorrowRecord
    {
        Id = 3,
        BorrowDate = new DateTime(2026, 9, 5),
        ReturnDate = new DateTime(2026, 9, 15),
        MemberId = 3,
        BookId = 2
    },
    new BorrowRecord
    {
        Id = 4,
        BorrowDate = new DateTime(2026, 9, 7),
        ReturnDate = new DateTime(2026, 9, 17),
        MemberId = 4,
        BookId = 4
    },
    new BorrowRecord
    {
        Id = 5,
        BorrowDate = new DateTime(2026, 9, 10),
        ReturnDate = new DateTime(2026, 9, 20),
        MemberId = 5,
        BookId = 5
    }
);

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LMS_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }


    }





        }

      

