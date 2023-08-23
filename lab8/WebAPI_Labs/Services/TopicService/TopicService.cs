using WebAPI_Labs.DTO;
using WebAPI_Labs.Extensions;
using WebAPI_Labs.Models;

namespace WebAPI_Labs.Services.TopicService
{
    public class TopicService : ITopicService
    {
        private List<Topic> _topics;

        public TopicService()
        {
            _topics = new List<Topic>
            {
                new Topic { Id=1, Title="Traveling to Europe", Description="Share your experiences and tips for traveling to Europe.", UserId=1},
                new Topic { Id=2, Title="Best books of the year", Description="What are your favorite books that you read this year?", UserId=2},
                new Topic { Id=3, Title="Healthy eating habits", Description="Share your tips and recipes for maintaining a healthy diet.", UserId=3},
                new Topic { Id=4, Title="Meditation and mindfulness", Description="Discuss the benefits and techniques of meditation and mindfulness.", UserId=4},
                new Topic { Id=5, Title="Learning a new language", Description="Share your experiences and advice for learning a new language.", UserId=5},
                new Topic { Id=6, Title="Photography tips and tricks", Description="Share your best photography tips and tricks for beginners.", UserId=6},
                new Topic { Id=7, Title="Home workout routines", Description="Share your favorite home workout routines and exercises.", UserId=7},
                new Topic { Id=8, Title="Gardening for beginners", Description="Share your tips and advice for starting a garden at home.", UserId=8},
                new Topic { Id=9, Title="Budgeting and saving money", Description="Share your best tips for budgeting and saving money.", UserId=9},
                new Topic { Id=10, Title="Sustainable living habits", Description="Discuss ways to live a more sustainable and eco-friendly lifestyle.", UserId=10}
            };
        }

        public async Task<Response<Topic>> GetAllAsync()
        {
            try
            {
                return await Task.FromResult(new Response<Topic>
                {
                    Code = 200,
                    Success = true,
                    Message = "Success",
                    Data = _topics
                });
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new Response<Topic>
                {
                    Code = 500,
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        public async Task<Response<Topic>> GetAsync(int id)
        {
            try
            {
                var topic = _topics.FirstOrDefault(t => t.Id == id);
                if (topic == null)
                {
                    return await Task.FromResult(new Response<Topic>
                    {
                        Code = 404,
                        Success = false,
                        Message = "Topic not found"
                    });
                }

                return await Task.FromResult(new Response<Topic>
                {
                    Code = 200,
                    Success = true,
                    Message = "Success",
                    Data = new List<Topic> { topic }
                });
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new Response<Topic>
                {
                    Code = 500,
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        public async Task<Response<Topic>> PostAsync(TopicDto topicDto)
        {
            try
            {
                int id = 1;
                if (_topics.Any())
                {
                    id = _topics.Max(t => t.Id) + 1;
                }
                var topic = topicDto.ToTopic(id);
                _topics.Add(topic);

                return await Task.FromResult(new Response<Topic>
                {
                    Code = 201,
                    Success = true,
                    Message = "Topic created",
                    Data = new List<Topic> { topic }
                });
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new Response<Topic>
                {
                    Code = 500,
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        public async Task<Response<Topic>> PutAsync(int id, TopicDto topicDto)
        {
            try
            {
                var topicIndex = _topics.FindIndex(t => t.Id == id);
                if (topicIndex == -1)
                {
                    return await Task.FromResult(new Response<Topic>
                    {
                        Code = 404,
                        Success = false,
                        Message = "Topic not found"
                    });
                }

                var topic = topicDto.ToTopic(id);
                _topics[topicIndex] = topic;

                return await Task.FromResult(new Response<Topic>
                {
                    Code = 200,
                    Success = true,
                    Message = "Topic updated",
                    Data = new List<Topic> { topic }
                });
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new Response<Topic>
                {
                    Code = 500,
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        public async Task<Response<Topic>> DeleteAsync(int id)
        {
            try
            {
                var topicIndex = _topics.FindIndex(t => t.Id == id);
                if (topicIndex == -1)
                {
                    return await Task.FromResult(new Response<Topic>
                    {
                        Code = 404,
                        Success = false,
                        Message = "Topic not found"
                    });
                }

                _topics.RemoveAt(topicIndex);

                return await Task.FromResult(new Response<Topic>
                {
                    Code = 200,
                    Success = true,
                    Message = "Topic deleted"
                });
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new Response<Topic>
                {
                    Code = 500,
                    Success = false,
                    Message = ex.Message
                });
            }
        }
    }

}
