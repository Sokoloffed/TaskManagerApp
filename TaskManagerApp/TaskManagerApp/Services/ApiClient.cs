using MvvmHelpers;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace TaskManagerApp.Serivces
{
    public class ApiClient
    {
        private string apiUri = @"";
        private static HttpClient httpClient = new HttpClient();

        public ApiClient(string uri)
        {
            this.apiUri = uri;
        }

        public async Task<ObservableRangeCollection<Users>> GetUsers()
        {
            //эти модели данных не для этого урла
            //поправь для этого, мы с этим тестим
            //и тип поменяй если надо а до своего апи без ngrok не достучаться?
            //ну .. можно...
            var result = new ObservableRangeCollection<Users>();

            var response = await httpClient.GetAsync(apiUri);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                var myObj = JsonConvert.DeserializeObject<ObservableRangeCollection<Users>>(json);
                if (!Equals(myObj, null))
                    result = myObj;
            }

            return result;

        }
    }
}
