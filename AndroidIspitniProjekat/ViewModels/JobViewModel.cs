using AndroidIspitniProjekat.Business.DTO;
using AndroidIspitniProjekat.Common;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidIspitniProjekat.ViewModels
{
    public class JobViewModel
    {
        
        public Prop<string> Keyword { get; set; } = new Prop<string>();
        public ObservableCollection<JobDto> Jobs { get; set; } = new ObservableCollection<JobDto>();

        public ObservableCollection<JobDto> AllJobs { get; set; } = new ObservableCollection<JobDto> { };
        public JobViewModel()
        {
            Keyword.OnChange = LoadJobs;

            LoadJobs();
        }

        private void LoadJobs()
        {
            if (!string.IsNullOrEmpty(Keyword.Value))
            {

                Jobs.Clear();
                var filteredJobs = AllJobs.Where(job =>
                    job.Company.Name.Contains(Keyword.Value) ||
                    (job.Position != null && job.Position.Name.Contains(Keyword.Value))
                ).ToList();

                foreach (var job in filteredJobs)
                {
                    Jobs.Add(job);
                }
            }
            else
            {
                string token = SecureStorage.Default.GetUser().Token;

                RestRequest request = new RestRequest("Job");

                var response = Api.Client.Execute<ApiResponse<JobDto>>(request);

                Console.WriteLine($"Status Code: {response.StatusCode}");
                Console.WriteLine($"Response Content: {response.Content}");

                if (response.IsSuccessful)
                {
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<JobDto>>(response.Content);
                var jobs = apiResponse?.Data;

                if (jobs != null)
                {
                    AllJobs.Clear();
                    Jobs.Clear();
                    foreach (var job in jobs)
                    {
                        this.AllJobs.Add(job);
                        this.Jobs.Add(job);
                    }
                }
                }
                else
                {
                    Console.WriteLine($"Error: {response.ErrorMessage}");
                }

            }
        }
    }
}
