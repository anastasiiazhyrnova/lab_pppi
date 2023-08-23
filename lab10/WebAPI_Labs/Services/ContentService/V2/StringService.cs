namespace WebAPI_Labs.Services.ContentService.V2
{
    public class StringService : IStringService
    {
        public Task<string> GetContent()
        {
            return Task.FromResult("random text");
        }
    }
}
