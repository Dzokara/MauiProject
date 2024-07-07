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
using System.Windows.Input;

namespace AndroidIspitniProjekat.ViewModels
{
    public class BlogViewModel
    {

        public ICommand ViewBlogDetailCommand { get; private set; }
        public ObservableCollection<BlogDto> Blogs { get; set; } = new ObservableCollection<BlogDto>();

        public BlogViewModel()
        {
            LoadBlogs();
        }

        public async Task<BlogDto> GetBlogByIdAsync(int blogId)
        {
            var blog = Blogs.FirstOrDefault(b => b.Id == blogId);
            if (blog != null)
            {
                return blog;
            }
            return null;
        }

        private void LoadBlogs()
        {
            
                string token = SecureStorage.Default.GetUser().Token;

                RestRequest request = new RestRequest("Blog");

                var response = Api.Client.Execute<ApiResponse<BlogDto>>(request);

                Console.WriteLine($"Status Code: {response.StatusCode}");
                Console.WriteLine($"Response Content: {response.Content}");

            
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<BlogDto>>(response.Content);
                var blogs = apiResponse?.Data;

                if (blogs != null)
                {
                    Blogs.Clear();
                    foreach (var blog in blogs)
                    {
                        this.Blogs.Add(blog);
                    }
                }
           
         
        }
    }
}
