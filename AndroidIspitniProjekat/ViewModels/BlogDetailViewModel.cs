using AndroidIspitniProjekat.Business.DTO;
using AndroidIspitniProjekat.Common;
using RestSharp;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AndroidIspitniProjekat.ViewModels
{
    public class BlogDetailViewModel
    {
        private AndroidIspitniProjekat.Business.DTO.User user = SecureStorage.Default.GetUser();
        private readonly BlogViewModel _parentViewModel;
        public ICommand GoBackCommand { get; }
        public ICommand AddCommentCommand { get; }
        public Prop<string> NewCommentText { get; set; } = new Prop<string>();
        public BlogDetailViewModel(BlogViewModel parentViewModel, int blogId)
        {
            GoBackCommand = new Command(OnGoBack);
            AddCommentCommand = new Command(OnAddComment);
            _parentViewModel = parentViewModel;
            Blog = new Prop<BlogDto>();

            LoadBlog(blogId);
        }

        public Prop<BlogDto> Blog { get; set; }

        private async void LoadBlog(int blogId)
        {
            var blog = await _parentViewModel.GetBlogByIdAsync(blogId);
            Blog.Value = blog;
        }
        private async void OnGoBack()
        {
            App.Current.MainPage = new MainPage();
        }

        private async void OnAddComment()
        { 
            var text = NewCommentText.Value;
            var authorId = user.Id;
            var blogId = Blog.Value.Id;
            var newComment = new CommentDto
            {
                Text =text,
                AuthorId = authorId,
                 blogId = blogId,
                 User = user
             };

            RestRequest request = new RestRequest("Comments", Method.Post);
            request.AddJsonBody(new { authorId, blogId, text });

            RestResponse response = await Api.Client.ExecuteAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                Blog.Value.Comments.Add(newComment);
                App.Current.MainPage = new BlogDetailPage(_parentViewModel, Blog.Value.Id);
            }
            else
            {
                
            }
        }


    }
}

