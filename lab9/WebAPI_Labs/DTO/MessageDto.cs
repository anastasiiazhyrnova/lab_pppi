namespace WebAPI_Labs.DTO
{
    public class MessageDto
    {
        public string Content { get; set; } = "";
        public DateTime DatePosted { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public int TopicId { get; set; }
    }
}
