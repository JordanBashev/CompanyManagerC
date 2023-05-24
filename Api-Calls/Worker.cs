using CompanyManagerC.Client;
using CompanyManagerC.Models;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Security.Policy;
using System.Text;

namespace CompanyManagerC.Api_Calls
{
    public class Worker<T> where T : class
    {
        public ApiClient _client = new ApiClient();

        public async Task<string> GetAll(string path)
        {
            string product = "";
            var response = await _client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsStringAsync();
            }

            return product;
        }

        public async Task<string> Get(int id, string path)
        {
            string product = "";
            var response = await _client.GetAsync(path + "/" + id);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsStringAsync();
            }

            return product;
        }

        public async Task<HttpStatusCode> Authenticate(T data, string path)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(path, content);

            return response.StatusCode;
        }

        public async Task<string> Post(T data, string path)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(path, content);

            var responseString = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseString);

            return responseString;
        }

        public async Task<string> Delete(int id, string path)
        {
            var content = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(path, content);

            var responseString = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseString);

            return responseString;
        }
    }
}
