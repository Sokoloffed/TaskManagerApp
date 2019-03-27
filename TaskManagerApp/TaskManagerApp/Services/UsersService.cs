﻿using MvvmHelpers;
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
                var myObj = JsonConvert.DeserializeObject<ObservableCollection<Users>>(json);
                //var myObj = JsonConvert.DeserializeObject<ObservableRangeCollection<Users>>(json);
                if (!Equals(myObj, null))
                    return myObj;
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

        public async Task<bool> PostUser(Users user)
        {
            var response = await httpClient.PostAsJsonAsync<Users>(this.apiClient.apiUri + "/Users/Post/", user);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else return false;
            
        }
    }
}
