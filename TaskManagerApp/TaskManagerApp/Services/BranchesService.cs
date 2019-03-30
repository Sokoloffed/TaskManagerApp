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
    public class BranchesService
    {
        ApiClient apiClient;
        HttpClient httpClient;

        public BranchesService()
        {
            this.apiClient = new ApiClient();
            this.httpClient = new HttpClient();
        }

        public async Task<ObservableCollection<Branches>> GetBranches()
        {
            var response = await httpClient.GetAsync(this.apiClient.apiUri + "Branches/Get");
            if(response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                var branches = JsonConvert.DeserializeObject<ObservableCollection<Branches>>(json);
                if (branches != null)
                    return branches;
            }
            return null;
        }

        public async Task<ObservableCollection<Branches>> GetCreator(int c_id)
        {
            var response = await httpClient.GetAsync(this.apiClient.apiUri + $"Branches/GetCreator?c_id={c_id}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                var branches = JsonConvert.DeserializeObject<ObservableCollection<Branches>>(json);
                if (branches != null)
                    return branches;
            }
            return null;
        }

        public async Task<Branches> GetName(string name)
        {
            var response = await httpClient.GetAsync(this.apiClient.apiUri + $"Branches/GetName?name={name}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                var branches = JsonConvert.DeserializeObject<Branches>(json);
                if (branches != null)
                    return branches;
            }
            return null;
        }

        public async Task<ObservableCollection<Branches>> GetBegin(DateTime begin)
        {
            var response = await httpClient.GetAsync(this.apiClient.apiUri + $"Branches/GetBegin?begin={begin}");
            if(response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                var branches = JsonConvert.DeserializeObject<ObservableCollection<Branches>>(json);
                if (branches != null)
                    return branches;
            }
            return null;
        }

        public async Task<bool> PostAsync(Branches branch)
        {
            var response = await httpClient.PostAsJsonAsync<Branches>(this.apiClient.apiUri + "Branches/Post/", branch);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else return false;
        }

        public async Task<bool> DeleteAsync(Branches branch)
        {
            var response = await httpClient.DeleteAsync(this.apiClient.apiUri + $"Branches/Delete?id={branch.id}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else return false;
        }
    }
}
