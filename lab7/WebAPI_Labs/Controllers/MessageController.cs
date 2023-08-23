using Microsoft.AspNetCore.Mvc;
using WebAPI_Labs.DTO;
using WebAPI_Labs.Services.MessageService;

namespace WebAPI_Labs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _messageService.GetAllAsync();
            return StatusCode(response.Code, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var response = await _messageService.GetAsync(id);
            return StatusCode(response.Code, response);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(MessageDto messageDto)
        {
            var response = await _messageService.PostAsync(messageDto);
            return StatusCode(response.Code, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, MessageDto messageDto)
        {
            var response = await _messageService.PutAsync(id, messageDto);
            return StatusCode(response.Code, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await _messageService.DeleteAsync(id);
            return StatusCode(response.Code, response);
        }
    }
}
