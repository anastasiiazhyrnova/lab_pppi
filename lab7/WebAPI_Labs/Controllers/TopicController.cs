using Microsoft.AspNetCore.Mvc;
using WebAPI_Labs.DTO;
using WebAPI_Labs.Services.TopicService;

namespace WebAPI_Labs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _topicService.GetAllAsync();
            return StatusCode(response.Code, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var response = await _topicService.GetAsync(id);
            return StatusCode(response.Code, response);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(TopicDto topicDto)
        {
            var response = await _topicService.PostAsync(topicDto);
            return StatusCode(response.Code, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, TopicDto topicDto)
        {
            var response = await _topicService.PutAsync(id, topicDto);
            return StatusCode(response.Code, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await _topicService.DeleteAsync(id);
            return StatusCode(response.Code, response);
        }
    }
}
