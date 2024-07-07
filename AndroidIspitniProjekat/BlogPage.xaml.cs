using AndroidIspitniProjekat.Business.DTO;
using AndroidIspitniProjekat.ViewModels;

namespace AndroidIspitniProjekat;

public partial class BlogPage : ContentPage
{
    private BlogViewModel _viewModel;
    public BlogPage()
    {
        InitializeComponent();
        _viewModel = new BlogViewModel();
        BindingContext = _viewModel;
    }

    private async void OnViewBlogDetailsClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var blog = button?.BindingContext as BlogDto;

        if (blog != null)
        {
            App.Current.MainPage =  new BlogDetailPage(_viewModel, blog.Id);
        }
    }
}