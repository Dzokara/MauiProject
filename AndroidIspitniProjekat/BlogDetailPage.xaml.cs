using AndroidIspitniProjekat.ViewModels;

namespace AndroidIspitniProjekat;

public partial class BlogDetailPage : ContentPage
{
    public BlogDetailPage(BlogViewModel parentViewModel, int blogId)
    {
        BindingContext = new BlogDetailViewModel(parentViewModel, blogId);
        InitializeComponent();
    }

   
}