namespace C03.CascadeDelete.Entities
{
    // Principal
    public class Author
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }

        public List<Book> Books { get; set; } = new();
    }
}
