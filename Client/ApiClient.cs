namespace CompanyManagerC.Client
{
    public class ApiClient : HttpClient
    {
        public ApiClient()
        {
            this.BaseAddress = new Uri("https://localhost:7070");
        }
    }
}
