using WebAPI_Labs.DTO;
using WebAPI_Labs.Models;

namespace WebAPI_Labs.Services.TopicService
{
    public interface ITopicService
    {
        Task<Response<Topic>> GetAllAsync();
        Task<Response<Topic>> GetAsync(int id);
        Task<Response<Topic>> PostAsync(TopicDto topic);
        Task<Response<Topic>> PutAsync(int id, TopicDto topic);
        Task<Response<Topic>> DeleteAsync(int id);
    }
}
