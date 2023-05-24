using CompanyManagerC.Client;
using CompanyManagerC.Models;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Security.Policy;
using System.Text;

namespace CompanyManagerC.Api_Calls
{
    public class Test
    {
        public ApiClient _client = new ApiClient();

        public async Task<string> GetProductAsync(string path)
        {
            string product = "";
            var response = await _client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsStringAsync();
            }

            return product;
        }

        public async Task<HttpStatusCode> Authenticate(string username, string password, string path)
        {
            var values = new Dictionary<string, string>
            {
              { "username", username },
              { "password", password },
            };

            var content = new FormUrlEncodedContent(values);
 
            var response = await _client.PostAsync(path, content);

            return response.StatusCode;
        }

        public async Task<string> createManager(Manager data, string path)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(path, content);

            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }
    }
}
