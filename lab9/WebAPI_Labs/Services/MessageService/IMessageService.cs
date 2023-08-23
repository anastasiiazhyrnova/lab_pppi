using WebAPI_Labs.DTO;
using WebAPI_Labs.Models;

namespace WebAPI_Labs.Services.MessageService
{
    public interface IMessageService
    {
        Task<Response<Message>> GetAllAsync();
        Task<Response<Message>> GetAsync(int id);
        Task<Response<Message>> PostAsync(MessageDto message);
        Task<Response<Message>> PutAsync(int id, MessageDto message);
        Task<Response<Message>> DeleteAsync(int id);
    }
}
