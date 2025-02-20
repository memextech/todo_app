using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using TodoWeb.Models;

namespace TodoWeb.Controllers;

public class TodoController : Controller
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;

    public TodoController(IConfiguration configuration)
    {
        _httpClient = new HttpClient();
        _apiBaseUrl = "http://localhost:5200/api/todo"; // API URL
    }

    // GET: Todo
    public async Task<IActionResult> Index()
    {
        var response = await _httpClient.GetAsync(_apiBaseUrl);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var todos = JsonSerializer.Deserialize<List<Todo>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return View(todos);
        }
        return Problem("Unable to fetch todos");
    }

    // GET: Todo/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Todo/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Title,IsComplete")] Todo todo)
    {
        if (ModelState.IsValid)
        {
            var json = JsonSerializer.Serialize(todo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_apiBaseUrl, content);
            
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
        }
        return View(todo);
    }

    // POST: Todo/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _httpClient.DeleteAsync($"{_apiBaseUrl}/{id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index));
        }
        return NotFound();
    }

    // POST: Todo/ToggleComplete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ToggleComplete(int id)
    {
        // First get the todo
        var response = await _httpClient.GetAsync($"{_apiBaseUrl}/{id}");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var todo = JsonSerializer.Deserialize<Todo>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (todo != null)
            {
                // Toggle the IsComplete status
                todo.IsComplete = !todo.IsComplete;

                // Update the todo
                var json = JsonSerializer.Serialize(todo);
                var putContent = new StringContent(json, Encoding.UTF8, "application/json");
                var putResponse = await _httpClient.PutAsync($"{_apiBaseUrl}/{id}", putContent);

                if (putResponse.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
        }
        return NotFound();
    }
}