using MvvmHelpers;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace TaskManagerApp.Serivces
{
    public class ApiClient
    {
        private const string apiUri = @"http://151393d6.ngrok.io/api/Users/Get";
        private static HttpClient httpClient = new HttpClient();

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
