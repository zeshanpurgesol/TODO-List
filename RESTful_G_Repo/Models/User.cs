namespace RESTful_G_Repo.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Status { get; set; } // active, blocked
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
