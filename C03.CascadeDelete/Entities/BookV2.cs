namespace C03.CascadeDelete.Entities
{
    // Dependent (FK)
    public class BookV2
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int? AuthorV2Id { get; set; } // FK
        public AuthorV2? AuthorV2 { get; set; }
    }
}
