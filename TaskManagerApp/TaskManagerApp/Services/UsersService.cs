using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManagerApp.Serivces;
using System.Web;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace TaskManagerApp.Services
{
    public class UsersService
    {
        ApiClient apiClient;
        HttpClient httpClient;

        public UsersService()
        {
            this.apiClient = new ApiClient();
            this.httpClient = new HttpClient();
        }

        //public async Task<ObservableRangeCollection<Users>> GetUsers()
        public async Task<ObservableCollection<Users>> GetUsers() 
        {
            //var result = new ObservableRangeCollection<Users>();
            var response = await httpClient.GetAsync(this.apiClient.apiUri + "Users/Get");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<ObservableCollection<Users>>(json);
                //var myObj = JsonConvert.DeserializeObject<ObservableRangeCollection<Users>>(json);
                if (!Equals(users, null))
                    return users;
                    //result = myObj;
            }

            return null;
            //return result;
        }


        public async Task<Users> GetUser(string name, string password)
        {
            var res = new Users();

            var response = await httpClient.GetAsync(this.apiClient.apiUri + "Users/Get" + "?username=" + name + "&password=" + password);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<Users>(json);
                if (!Equals(user, null))
                    res = user;
            }
            return res;
        }

        public async Task<bool> PostUserAsync(Users user)
        {
            var response = await httpClient.PostAsJsonAsync<Users>(this.apiClient.apiUri + "Users/Post/", user);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else return false;            
        }

        public bool PostUserSync(Users user)
        {
            bool res = false;
            var HClient = new HttpClient
            {
                BaseAddress = new Uri(this.apiClient.apiUri)
            };
            var response = HClient.PostAsJsonAsync("Users/Post/", user);
            response.Wait();
            if (response.Result.StatusCode == HttpStatusCode.OK)
            {
                var jsonT = response.Result.Content.ReadAsStringAsync();
                jsonT.Wait();
                bool isPost = JsonConvert.DeserializeObject<bool>(jsonT.Result);
                res = isPost;
            }
            return res;
        }

        public async Task<bool> DeleteUserAsync(Users user)
        {
            var response = await httpClient.DeleteAsync(this.apiClient.apiUri + $"/Users/Delete?id={user.id}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else return false;
        }

        public bool DeleteUserSync(Users user)
        {
            bool res = false;
            var response = httpClient.DeleteAsync(this.apiClient.apiUri + $"Users/Delete?id={user.id}");
            response.Wait();
            if(response.Result.StatusCode == HttpStatusCode.OK)
            {
                res = true;
            }
            return res;
        }
    }
}
