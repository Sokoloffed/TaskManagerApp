﻿using MvvmHelpers;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace TaskManagerApp.Serivces
{
    public class ApiClient
    {
        public string apiUri = @"http://ce1673c5.ngrok.io/api/";
        private static HttpClient httpClient = new HttpClient();

        public ApiClient()
        {
            //this.apiUri = uri;
        }

        
    }
}
