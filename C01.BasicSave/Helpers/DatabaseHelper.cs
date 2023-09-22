using C01.BasicSaveWithTracking.Data;
using C01.BasicSaveWithTracking.Entities;
using Microsoft.EntityFrameworkCore;

namespace C01.BasicSaveWithTracking.Helpers
{
    public static class DatabaseHelper
    {
        public static void RecreateCleanDatabase()
        {
            using var context = new AppDbContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        public static void PopulateDatabase()
        {
            using (var context = new AppDbContext())
            {
                context.Add(
                    new Author
                    {
                        Id = 1,
                        FName = "Eric",
                        LName = "Evans",
                        Books = new List<Book>
                        {
                          new Book
                          {
                              Id = 1,
                              Title = "Domain-Driven Design: Tackling Complexity in the Heart of Software"
                          },
                          new Book
                          {
                              Id = 2,
                              Title = "Domain-Driven Design Reference: Definitions and Pattern Summaries"
                          }
                        }
                    });

                context.Add(
                   new Author
                   {
                       Id = 2,
                       FName = "John",
                       LName = "Skeet",
                       Books = new List<Book>
                       {
                          new Book
                          {
                              Id = 3,
                              Title = "C# In Depth"
                          },
                          new Book
                          {
                              Id = 4,
                              Title = "Real world functional programming"
                          }
                       }
                   });

                context.Add(new Author { Id = 3, FName = "Aditya", LName = "Bhargava" });


                context.SaveChanges();
            }
        }

        public static Book? GetDisconnectedBook()
        {
            using var tempContext = new AppDbContext();
            return tempContext.Books.Find(2);
        }

        public static Author GetDisconnectedAuthorAndBooks()
        {
            using var tempContext = new AppDbContext();
            return tempContext.Authors.Include(x => x.Books).Single();
        }
    }
}
