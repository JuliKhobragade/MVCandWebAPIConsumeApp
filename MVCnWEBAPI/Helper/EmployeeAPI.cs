namespace MVCnWEBAPI.Helper
{
    public class EmployeeAPI
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7191/");
            return client;
        }
    }
}
