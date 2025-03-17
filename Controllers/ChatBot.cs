using Microsoft.AspNetCore.Mvc;
using ChatBot.Models;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Text;
using System.Reflection;

namespace ChatBot.Controllers
{
    public class ChatBot : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public ChatBot(IOptions<OpenAISettings> openAiSettings)
        {
            _httpClient = new HttpClient();
            _apiKey = openAiSettings.Value.ApiKey;
        }

        public async Task<string> GetChatResponse(string prompt)
        {
            try
            {
                string models = "gpt-3.5-turbo";
                var requestBody = new
                {
                    model = models,
                    max_tokens = 50, 
                    messages = new[] { new { role = "user", content = prompt } }
                };

                var requestJson = JsonSerializer.Serialize(requestBody);
                var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);

                string apiUrl = models.Contains("gpt-4") || models.Contains("gpt-3.5")
                ? "https://api.openai.com/v1/chat/completions"
             : "https://api.openai.com/v1/completions";

                var response = await _httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }

                if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                {
                    return "OpenAI API rate limit exceeded. Please wait and try again.";
                }

                return $"OpenAI API call failed: {response.ReasonPhrase}";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public async Task<IActionResult> AiChatBot(ChatBotModel CB)
        {
            if (string.IsNullOrWhiteSpace(CB.prompt))
            {
                ViewBag.ResponseMessage = "Please enter a message.";
                return View();
            }

            string response = await GetChatResponse(CB.prompt);
            ViewBag.ResponseMessage = response;

            return View();
        }
    }
}
