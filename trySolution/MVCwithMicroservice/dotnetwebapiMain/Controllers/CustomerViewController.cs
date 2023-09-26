using Microsoft.AspNetCore.Mvc;
using dotnetwebapiMain.Models;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text;
namespace dotnetwebapiMain.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerViewController : ControllerBase
{
    Uri baseaddress = new Uri("https://localhost:7214/");
    private readonly HttpClient client;

    public CustomerViewController()
    {
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

        client = new HttpClient(clientHandler);
        client.BaseAddress = baseaddress;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomers()
    {
        try
        {
            List<Customer> listCustomers = new List<Customer>();
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress + "Customer");

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                listCustomers = JsonConvert.DeserializeObject<List<Customer>>(data);

                return Ok(listCustomers); // Return the list of customers as an HTTP 200 OK response
            }
            else
            {
                // Handle the case where the request was not successful
                // Log or handle the error as needed
                Console.WriteLine("Error: " + response.StatusCode);
                return StatusCode((int)response.StatusCode); // Return the HTTP status code as a response
            }
        }
        catch (Exception ex)
        {
            // Log or print the exception to get more details
            Console.WriteLine("Exception: " + ex.Message);

            // Return an error response
            return StatusCode(500); // Internal Server Error
        }
    }
}