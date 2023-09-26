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
public class CustomerAdditionController : ControllerBase
{
    Uri baseaddress = new Uri("https://localhost:7414/");
    private readonly HttpClient client;

    public CustomerAdditionController()
    {
         HttpClientHandler clientHandler = new HttpClientHandler();
clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

        client = new HttpClient(clientHandler);
        client.BaseAddress = baseaddress;
    }

    //
    [HttpPost]
public async Task<IActionResult> AddCustomer(Customer customer)
{
    try
    {
        if (!ModelState.IsValid)
        {
            // Model validation failed, return BadRequest with error details
            return BadRequest(ModelState);
        }

        // Serialize the Customer object to JSON
        string customerJson = JsonConvert.SerializeObject(customer);

        // Create a StringContent with JSON data
        var content = new StringContent(customerJson, Encoding.UTF8, "application/json");

        // Send a POST request to your Web API endpoint
        HttpResponseMessage response = await client.PostAsync("Customer", content);

        // Check if the request was successful
        if (response.IsSuccessStatusCode)
        {
            // Customer added successfully, you can return a JSON response or other data
            var responseData = await response.Content.ReadAsStringAsync();
            return Content(responseData, "application/json"); // Return JSON response
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