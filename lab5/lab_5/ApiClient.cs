using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;


namespace lab_5
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        public ApiClient()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ApiModel> Get()
        {
            string type = "users";
            string num = "1";
            string url = $"https://jsonplaceholder.typicode.com/{type}/{num}";
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{url}");
                string content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<UserResult>(content);
                return new ApiModel
                {
                    Message = "Success",
                    StatusCode = response.StatusCode,
                    Result = new List<UserResult> { data }
                };
            }

            catch (Exception ex)
            {
                return new ApiModel
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = ex.Message
                };
            }
        }

        public async Task<ApiModel> Post(string type, string id)
        {
            try
            {
                string url = "https://jsonplaceholder.typicode.com";
                var content = new StringContent("", null, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync($"{url}/{type}/{id}", content);
                string content_resp = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<UserResult>(content_resp);
                return new ApiModel
                {
                    Message = "Success",
                    StatusCode = response.StatusCode,
                    Result = new List<UserResult> { data }
                };
            }
            catch (Exception ex)
            {
                return new ApiModel
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = ex.Message
                };
            }
        }
    }
}
