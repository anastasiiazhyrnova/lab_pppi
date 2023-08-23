namespace WebAPI_Labs.Services.ContentService.V1
{
    public class NumberService : INumberService
    {
        public Task<int> GetContent()
        {
            return Task.FromResult(1);
        }
    }
}
