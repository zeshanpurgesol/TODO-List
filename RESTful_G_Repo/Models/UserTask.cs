namespace RESTful_G_Repo.Models
{
    public class UserTask
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Status { get; set; } // complete, pending
        public string? TaskName { get; set; }
        public string? TaskDetails { get; set; }
    }
}
