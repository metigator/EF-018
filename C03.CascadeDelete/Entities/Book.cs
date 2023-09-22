namespace C03.CascadeDelete.Entities
{
    // Dependent (FK)
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int AuthorId { get; set; } // FK
        public Author Author { get; set; }
    }
}
