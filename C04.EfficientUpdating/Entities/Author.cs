namespace C06.Interceptors.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }

        public List<Book> Books { get; set; } = new();
    }
}
