using C01.SqlQuery.Data;
using C06.Interceptors.Entities;
using Microsoft.EntityFrameworkCore;

namespace C06.Interceptors.Helpers
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
                              Title = "Domain-Driven Design: Tackling Complexity in the Heart of Software",
                              Price = 50
                          },
                          new Book
                          {
                              Id = 2,
                              Title = "Domain-Driven Design Reference: Definitions and Pattern Summaries",
                              Price = 50
                          },
                          new Book
                          {
                              Id = 3,
                              Title = "Book #3",
                              Price = 50
                          },
                          new Book
                          {
                              Id = 4,
                              Title = "Book #4",
                              Price = 50
                          },
                          new Book
                          {
                              Id = 5,
                              Title = "Book #5",
                              Price = 50
                          },
                          new Book
                          {
                              Id = 6,
                              Title = "Book #6",
                              Price = 50
                          },
                          new Book
                          {
                              Id = 7,
                              Title = "Book #7",
                              Price = 50
                          },
                          new Book
                          {
                              Id = 8,
                              Title = "Book #8",
                              Price = 50
                          },
                          new Book
                          {
                              Id = 9,
                              Title = "Book #9",
                              Price = 50
                          }
                        },
                    });

                context.Authors.Add(
                    new Author
                    {
                        Id = 2,
                        FName = "John",
                        LName = "Skeet",
                        Books = new List<Book>
                        {
                          new Book
                          {
                              Id = 10,
                              Title = "C# In Depth",
                              Price = 50
                          },
                        }
                    });

                context.SaveChanges();
            }
        }

        public static Book GetDisconnectedBook()
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
