using WebAPI_Labs.DTO;
using WebAPI_Labs.Models;

namespace WebAPI_Labs.Extensions
{
    public static class TopicExtensions
    {
        public static Topic ToTopic(this TopicDto topicDto, int id)
        {
            return new Topic
            {
                Id = id,
                Title = topicDto.Title,
                Description = topicDto.Description,
                UserId = topicDto.UserId
            };
        }
    }
}
