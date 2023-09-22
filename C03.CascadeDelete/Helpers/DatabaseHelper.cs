using C01.SqlQuery.Data;
using C03.CascadeDelete.Entities;
using Microsoft.EntityFrameworkCore;

namespace C03.CascadeDelete.Helpers
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
                 new AuthorV2
                 {
                     Id = 1,
                     FName = "Eric",
                     LName = "Evans",
                     BookV2s = new List<BookV2>
                     {
                          new BookV2
                          {
                              Id = 1,
                              Title = "Domain-Driven Design: Tackling Complexity in the Heart of Software"
                          },
                          new BookV2
                          {
                              Id = 2,
                              Title = "Domain-Driven Design Reference: Definitions and Pattern Summaries"
                          }
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
