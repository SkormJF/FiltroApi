using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace FiltroApi.Services{
    public class EmailsServices{
        private readonly string _apiToken;
        private readonly HttpClient _httpClient;

        public EmailsServices(IConfiguration configuration){
            _apiToken = configuration["MailerSend:ApiToken"];
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiToken}");
            _httpClient.BaseAddress = new Uri("https://api.mailersend.com/v1/");
        }

        public async Task SendEmailAsync(string from, string fromName, List<string> to, List<string> toName, string subject, string text, string html){
            var emailData = new{ 
                from = new { email = from, name = fromName},
                to = to.ConvertAll(email => new {email, name = toName[to.IndexOf(email)]}),
                subject,
                text,
                html
            };

            var jsonContent = JsonSerializer.Serialize(emailData);
            var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("email", content);

            if(!response.IsSuccessStatusCode){
                var responseBody = await response.Content.ReadAsStringAsync();
                throw new Exception($"Didn't send the email: {response.ReasonPhrase}. Details: {responseBody}");
            }
        }
    }
}