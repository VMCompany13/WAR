using Newtonsoft.Json;
using System.Text;
using BackendDataService.Models;
using BackendDataService.Models.Dto;

namespace WebApService.Services
{
    public class UsersService : IUsersService
    {
        public async Task CreateUserAsync(NewUserDto newUser)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:5001/users/createUser"),
                Content = new StringContent(JsonConvert.SerializeObject(newUser), Encoding.UTF8,
                                    "application/json")
            };
            await GetHttpClientSendAsync(request);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://localhost:5001/users")            
            };
            using var client = new HttpClient();

            var response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<List<User>>(responseBody);
        }


        private async Task<T> GetHttpClientSendAsyncAndReturnValue<T>(HttpRequestMessage httpRequest)
        {
            using var client = new HttpClient();

            var response = await client.SendAsync(httpRequest).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<T>(responseBody);

        }

        private async Task GetHttpClientSendAsync(HttpRequestMessage httpRequest)
        {
            using var client = new HttpClient();

            var response = await client.SendAsync(httpRequest).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }

    }
}
