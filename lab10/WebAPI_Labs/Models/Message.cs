namespace WebAPI_Labs.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; } = "";
        public DateTime DatePosted { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public int TopicId { get; set; }
    }
}
