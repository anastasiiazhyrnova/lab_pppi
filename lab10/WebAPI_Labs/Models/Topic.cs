namespace WebAPI_Labs.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public int UserId { get; set; }
    }
}
