using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using SwapiMVC.Models;

namespace SwapiMVC.Controllers
{
    public class PeopleController : Controller
    {
        private readonly HttpClient _httpClient; // Establishes a private field to go inside the constructor
        public PeopleController(IHttpClientFactory httpClientFactory) // Constructor for PeopleController class
        {
            _httpClient = httpClientFactory.CreateClient("swapi"); // Setting the new private field _httpClient equal to httpClientFactory and invoke the CreateClient method
        }
        public async Task<IActionResult> Index(string page)
        {
            string route = $"people?page={page ?? "1"}"; // No idea what this is
            HttpResponseMessage response = await _httpClient.GetAsync(route); // Stepping into the _httpClient field and performing Async function using the route created above as a parameter

            var responseString = await response.Content.ReadAsStringAsync(); // Grabbing the content from the HttpResponseMessage response as a string
            var people = JsonSerializer.Deserialize<ResultsViewModel<PeopleViewModel>>(responseString); // Deserializing this string from JSON to C# object, a ResultsViewModel that contains a collection of PeopleViewModel objects

            return View(people);
        }
    }
}