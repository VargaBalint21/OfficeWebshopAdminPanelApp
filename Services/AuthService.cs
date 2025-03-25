using OfficeWebshopAdminPanelApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OfficeWebshopAdminPanelApp.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private string _token;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            var json = JsonSerializer.Serialize(new { email, password });
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://your-laravel-api.com/api/login", content);
            if (!response.IsSuccessStatusCode) return false;

            var responseContent = await response.Content.ReadAsStringAsync();
            var user = JsonSerializer.Deserialize<UserModel>(responseContent);

            _token = user.Token;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            return true;
        }
    }
}
