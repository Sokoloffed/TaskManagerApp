using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;

namespace TaskManagerApp
{
    public class Service
    {
        const string urlUsers = "http://localhost:50368/api/Users/";
        const string urlTasks = "http://localhost:50368/api/Tasks/";
        const string urlBranches = "http://localhost:50368/api/Branches/";
        public IEnumerable<Users> allUsers;


        public Service()
        {
            //GetUser();
        }
        //
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task<IEnumerable<Users>> GetAllUsers()
        {

            IEnumerable<Users> usr = new List<Users>();
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("http://localhost:50368/api/Users/Get"),
                    Method = HttpMethod.Get
                };
                request.Headers.Add("Accept", "application/json");
                var response = client.SendAsync(request);
                response.Start();

                if(response.IsCompleted)
                {
                    var json = response.Result.ToString();// .Content.ReadAsStringAsync();
                    var myObj = JsonConvert.DeserializeObject<ObservableCollection<Users>>(json);
                    if (!Equals(myObj, null))
                        return myObj;
                }
            }
            return usr;
        } 

        public async Task<Users> GetUser()
        {
            using(var client = new HttpClient())
            {
                Uri uri = new Uri("http://localhost:50368/api/Users/Get/3");
                var response = client.GetAsync("http://localhost:50368/api/Users/Get/3").Result;
                if (response.IsSuccessStatusCode)
                {
                    var dataobj = response.Content.ReadAsAsync<Users>().Result;
                    return dataobj;
                }
                else
                {
                    int cd = (int)response.StatusCode;
                    return null;
                }

            }
        }

        public async Task<IEnumerable<Tasks>> GetAllTasks()
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(urlTasks + "Get");
            return JsonConvert.DeserializeObject<IEnumerable<Tasks>>(result);
        }

        public async Task<IEnumerable<Branches>> GetAllBranches()
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(urlBranches + "Get");
            return JsonConvert.DeserializeObject<IEnumerable<Branches>>(result);
        }
    }
}
