namespace Web_Empleados.Helpers
{
    public class InformationExtends
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7048/");
            return client;
        }
    }
}
