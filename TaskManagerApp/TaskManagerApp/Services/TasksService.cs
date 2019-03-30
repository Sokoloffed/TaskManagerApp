using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TaskManagerApp.Serivces;

namespace TaskManagerApp.Services
{
    public class TaskService
    {
        ApiClient apiClient;
        HttpClient httpClient;

        public TaskService()
        {
            this.apiClient = new ApiClient();
            this.httpClient = new HttpClient();
        }

        public async Task<ObservableCollection<Tasks>> GetTasks()
        {
            var response = 
        }
    }
}
