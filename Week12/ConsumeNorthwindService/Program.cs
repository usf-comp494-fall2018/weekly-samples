using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace ConsumeNorthwindService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calling Web Service...");
            var client = new RestClient("https://localhost:44328");

            var request = new RestRequest("api/customers/");
            request.AddParameter("country", "Germany");

            IRestResponse response = client.Execute(request);
            Console.WriteLine("Processing results ...");
            var content = response.Content;
            var customers = JsonConvert.DeserializeObject<List<Customer>>(content);

            Console.WriteLine("Our Customers:");
            foreach (var customer in customers)
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine($"{customer.ContactName} - {customer.ContactTitle}");
                Console.WriteLine($"{customer.CompanyName}");
                Console.WriteLine($"{customer.Address}");
                Console.WriteLine($"{customer.City}, {customer.Region}, {customer.Country} {customer.PostalCode}");
                Console.WriteLine($"{customer.Phone}");
            }
        }
    }
}
