using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TaskManagerApp.Serivces;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;

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
            var response = await httpClient.GetAsync(this.apiClient.apiUri + "Tasks/Get");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                var tasks = JsonConvert.DeserializeObject<ObservableCollection<Tasks>>(json);
                if (!Equals(tasks, null))
                    return tasks;
            }
            return null;
        }

        public async Task<ObservableCollection<Tasks>> GetTasksBegin(DateTime begin)
        {
            var response = await httpClient.GetAsync(this.apiClient.apiUri + "Tasks/GetBegin" + $"?begin={begin}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                var tasks = JsonConvert.DeserializeObject<ObservableCollection<Tasks>>(json);
                if (!Equals(tasks, null))
                    return tasks;
            }
            return null;
        }

        public async Task<Tasks> GetTasksName(string taskname)
        {
            var response = await httpClient.GetAsync(this.apiClient.apiUri + "Tasks/GetName" + $"?name={taskname}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                var task = JsonConvert.DeserializeObject<Tasks>(json);
                if (!Equals(task, null))
                    return task;
            }
            return null;
        }

        public async Task<ObservableCollection<Tasks>> GetTasksEnd(DateTime end)
        {
            var response = await httpClient.GetAsync(this.apiClient.apiUri + "Tasks/GetEnd" + $"?end={end}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                var task = JsonConvert.DeserializeObject<ObservableCollection<Tasks>>(json);
                if (!Equals(task, null))
                    return task;
            }
            return null;
        }

        public async Task<ObservableCollection<Tasks>> GetTasksStatus(string stat)
        {
            var response = await httpClient.GetAsync(this.apiClient.apiUri + "Tasks/GetStatus" + $"?status={stat}");
            if(response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                var task = JsonConvert.DeserializeObject<ObservableCollection<Tasks>>(json);
                if (task != null)
                    return task;
            }
            return null;
        }

        public async Task<ObservableCollection<Tasks>> GetTasksCreator(int i_id)
        {
            var response = await httpClient.GetAsync(this.apiClient.apiUri + "Tasks/GetCreator" + $"?c_id={i_id}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                var task = JsonConvert.DeserializeObject<ObservableCollection<Tasks>>(json);
                if (task != null)
                    return task;
            }
            return null;
        }

        public async Task<ObservableCollection<Tasks>> GetTasksExecutor(int e_id)
        {
            var response = await httpClient.GetAsync(this.apiClient.apiUri + "Tasks/GetStatus" + $"?e_id={e_id}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                var task = JsonConvert.DeserializeObject<ObservableCollection<Tasks>>(json);
                if (task != null)
                    return task;
            }
            return null;
        }

        public async Task<bool> PostAsync(Tasks task)
        {
            var response = await httpClient.PostAsJsonAsync<Tasks>(this.apiClient.apiUri + "Tasks/Post/", task);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else return false;
        }

        public async Task<bool> DeleteAsync(Tasks task)
        {
            var response = await httpClient.DeleteAsync(this.apiClient.apiUri + $"Tasks/Delete?id={task.id}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else return false;
        }
    }

}