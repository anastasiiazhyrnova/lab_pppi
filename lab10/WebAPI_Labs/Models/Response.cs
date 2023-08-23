namespace WebAPI_Labs.Models
{
    public class Response<T>
    {
        public int Code { get; set; } = 400;
        public bool Success { get; set; } = false;
        public string Message { get; set; } = "";
        public List<T> Data { get; set; } = new List<T>();
    }
}
