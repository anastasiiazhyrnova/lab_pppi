using Newtonsoft.Json;
using System.Net;

namespace lab_5
{
    public partial class UserResult
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        public string Phone { get; set; }
        public string Website { get; set; }

        [JsonProperty("company")]
        public Company Company { get; set; }
    }

    public partial class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
    }

    public partial class Company
    {
        public string Name { get; set; }
        public string Bs { get; set; }
    }

    public class ApiModel
    {
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public List<UserResult> Result { get; set; }

        public void PrintResult()
        {
            Console.WriteLine($"Message {Message}");
            Console.WriteLine($"StatusCode: {StatusCode}");
            if (Message == "Success")
            {
                Console.WriteLine($"Id: {Result[0].Id}");
                Console.WriteLine($"Name: {Result[0].Name}");
                Console.WriteLine($"Username: {Result[0].Username}");
                Console.WriteLine($"Email: {Result[0].Email}");
                Console.WriteLine("Address");
                Console.WriteLine($"Street: {Result[0].Address.Street}");
                Console.WriteLine($"City: {Result[0].Address.City}");
                Console.WriteLine($"Zipcode: {Result[0].Address.Zipcode}");
                Console.WriteLine($"Phone: {Result[0].Phone}");
                Console.WriteLine($"Website: {Result[0].Website}");
                Console.WriteLine("Company");
                Console.WriteLine($"Name: {Result[0].Company.Name}");
                Console.WriteLine($"Bs: {Result[0].Company.Bs}");
            }
        }
    }
}
