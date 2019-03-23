using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace TaskManagerApp.Serivces
{
    public class ApiClient
    {
        private const string apiUri = @"https://rsreu.ru/schedule/540.json";
        private static HttpClient httpClient = new HttpClient();

        public async Task<string[]> GetService()
        {
            //эти модели данных не для этого урла
            //поправь для этого, мы с этим тестим
            //и тип поменяй если надо а до своего апи без ngrok не достучаться?
            //ну .. можно...
            var result = new string[0];

            var response = await httpClient.GetAsync(apiUri);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                var myObj = JsonConvert.DeserializeObject<string[]>(json);
                if (!Equals(myObj, null))
                    result = myObj;
            }

            return result;

        }
    }
}
