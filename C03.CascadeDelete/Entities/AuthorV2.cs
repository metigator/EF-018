namespace C03.CascadeDelete.Entities
{
    // Principal
    public class AuthorV2
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }

        public List<BookV2> BookV2s { get; set; } = new();
    }
}
