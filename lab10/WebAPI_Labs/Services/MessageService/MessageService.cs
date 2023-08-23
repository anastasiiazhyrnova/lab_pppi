using WebAPI_Labs.DTO;
using WebAPI_Labs.Extensions;
using WebAPI_Labs.Models;

namespace WebAPI_Labs.Services.MessageService
{
    public class MessageService : IMessageService
    {
        private List<Message> _messages;

        public MessageService()
        {
            _messages = new List<Message>
            {
                new Message{Id=1, Content="I recently traveled to Italy and it was amazing. The food, the culture, the history... everything was incredible!", DatePosted=new DateTime(2023,1,1), UserId=1, TopicId=1},
                new Message{Id=2, Content="One of my favorite books this year was 'The Midnight Library' by Matt Haig. It's a thought-provoking and heartwarming story about the choices we make in life.", DatePosted=new DateTime(2023,1,2), UserId=2, TopicId=2},
                new Message{Id=3, Content="I've found that meal planning and prepping has really helped me stick to a healthy diet. It takes some time upfront but it's worth it in the long run.", DatePosted=new DateTime(2023,1,3), UserId=3, TopicId=3},
                new Message{Id=4, Content="I started meditating regularly a few months ago and it has really helped me manage stress and anxiety. I use the Headspace app and it's been great.", DatePosted=new DateTime(2023,1,4), UserId=4, TopicId=4},
                new Message{Id=5, Content="I've been learning Spanish using the Duolingo app and it's been really helpful. It's fun and easy to use, and I've made a lot of progress.", DatePosted=new DateTime(2023,1,5), UserId=5, TopicId=5},
                new Message{Id=6, Content="One of my favorite photography tips is to play with lighting. Experiment with different light sources and angles to create interesting effects.", DatePosted=new DateTime(2023,1,6), UserId=6, TopicId=6},
                new Message{Id=7, Content="I love doing bodyweight exercises at home. Squats, push-ups, lunges... there are so many options and you don't need any equipment.", DatePosted=new DateTime(2023,1,7), UserId=7, TopicId=7},
                new Message{Id=8, Content="I started a small herb garden on my balcony and it's been so rewarding. Fresh herbs make such a difference in cooking and it's been fun to watch them grow.", DatePosted=new DateTime(2023,1,8), UserId=8, TopicId=8},
                new Message{Id=9, Content="I've found that tracking my expenses and setting a budget has really helped me save money. It's not always fun but it's worth it in the long run.", DatePosted=new DateTime(2023,1,9), UserId=9, TopicId=9},
                new Message{Id=10, Content="One simple way to live more sustainably is to reduce single-use plastics. Bring your own reusable bags, water bottles, and containers when you can.", DatePosted=new DateTime(2023,1,10), UserId=10, TopicId=10}
            };
        }

        public async Task<Response<Message>> GetAllAsync()
        {
            try
            {
                return await Task.FromResult(new Response<Message>
                {
                    Code = 200,
                    Success = true,
                    Message = "Success",
                    Data = _messages
                });
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new Response<Message>
                {
                    Code = 500,
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        public async Task<Response<Message>> GetAsync(int id)
        {
            try
            {
                var message = _messages.FirstOrDefault(m => m.Id == id);
                if (message == null)
                {
                    return await Task.FromResult(new Response<Message>
                    {
                        Code = 404,
                        Success = false,
                        Message = "Message not found"
                    });
                }

                return await Task.FromResult(new Response<Message>
                {
                    Code = 200,
                    Success = true,
                    Message = "Success",
                    Data = new List<Message> { message }
                });
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new Response<Message>
                {
                    Code = 500,
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        public async Task<Response<Message>> PostAsync(MessageDto messageDto)
        {
            try
            {
                int id = 1;
                if (_messages.Any())
                {
                    id = _messages.Max(m => m.Id) + 1;
                }
                var message = messageDto.ToMessage(id);
                _messages.Add(message);

                return await Task.FromResult(new Response<Message>
                {
                    Code = 201,
                    Success = true,
                    Message = "Message created",
                    Data = new List<Message> { message }
                });
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new Response<Message>
                {
                    Code = 500,
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        public async Task<Response<Message>> PutAsync(int id, MessageDto messageDto)
        {
            try
            {
                var messageIndex = _messages.FindIndex(m => m.Id == id);
                if (messageIndex == -1)
                {
                    return await Task.FromResult(new Response<Message>
                    {
                        Code = 404,
                        Success = false,
                        Message = "Message not found"
                    });
                }

                var message = messageDto.ToMessage(id);
                _messages[messageIndex] = message;

                return await Task.FromResult(new Response<Message>
                {
                    Code = 200,
                    Success = true,
                    Message = "Message updated",
                    Data = new List<Message> { message }
                });
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new Response<Message>
                {
                    Code = 500,
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        public async Task<Response<Message>> DeleteAsync(int id)
        {
            try
            {
                var messageIndex = _messages.FindIndex(m => m.Id == id);
                if (messageIndex == -1)
                {
                    return await Task.FromResult(new Response<Message>
                    {
                        Code = 404,
                        Success = false,
                        Message = "Message not found"
                    });
                }

                _messages.RemoveAt(messageIndex);

                return await Task.FromResult(new Response<Message>
                {
                    Code = 200,
                    Success = true,
                    Message = "Message deleted"
                });
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new Response<Message>
                {
                    Code = 500,
                    Success = false,
                    Message = ex.Message
                });
            }
        }
    }
}
