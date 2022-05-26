using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }
    }
}