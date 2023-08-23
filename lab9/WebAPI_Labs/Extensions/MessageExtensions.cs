using WebAPI_Labs.DTO;
using WebAPI_Labs.Models;

namespace WebAPI_Labs.Extensions
{
    public static class MessageExtensions
    {
        public static Message ToMessage(this MessageDto messageDto, int id)
        {
            return new Message
            {
                Id = id,
                Content = messageDto.Content,
                DatePosted = messageDto.DatePosted,
                UserId = messageDto.UserId,
                TopicId = messageDto.TopicId
            };
        }
    }
}
