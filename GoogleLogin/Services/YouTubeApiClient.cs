using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Net;
using System.Threading.Channels;
using static Google.Apis.Requests.BatchRequest;

namespace GoogleLogin.Services
{
    public class YouTubeApiClient
    {
        HttpClient _httpClient;
        public YouTubeApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> GetUsersAsync(string apiKey,string id)
        {
            try
            {
                HttpResponseMessage respons = await _httpClient.GetAsync($"");
                if (respons.IsSuccessStatusCode)
                {
                    string content = await respons.Content.ReadAsStringAsync();
                    return content;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        


    }
}
