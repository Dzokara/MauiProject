using AndroidIspitniProjekat.Business.DTO;
using AndroidIspitniProjekat.Common;
using AndroidIspitniProjekat.Validators;
using FluentValidation.Results;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AndroidIspitniProjekat.ViewModels
{
    public class AdminBlogViewModel
    {

        public Prop<string> Image {  get; set; } = new Prop<string>();
        public Prop<string> Title { get; set; } = new Prop<string>();
        public Prop<string> Description { get; set; } = new Prop<string>();

        public Prop<bool> ButtonEnabled { get; set; } = new Prop<bool>();

        public ICommand SubmitCommand { get; }
        public ICommand PickImageCommand { get; }

        public AdminBlogViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
            PickImageCommand = new Command(OnPickImage);

            Image.OnChange = Validate;
            Title.OnChange = Validate;
            Description.OnChange = Validate;
            ButtonEnabled.Value = false;
        }

 

        private void Validate()
        {
            BlogInsertValidator validator = new BlogInsertValidator();
            ValidationResult result = validator.Validate(this);

            Title.Error = result.GetError("Title");
            Image.Error = result.GetError("Image");
            Description.Error = result.GetError("Description");
            ButtonEnabled.Value = result.IsValid;
        }

        private async void OnSubmit()
        {
            var title = Title.Value;
            var description = Description.Value;
            var image = Image.Value;
            var request = new RestRequest("Blog", Method.Post);
            request.AddParameter("Title", title);
            request.AddParameter("Description", description);

            if (!string.IsNullOrEmpty(Image.Value))
            {
                request.AddFile("image", Image.Value);
            }

            var response = await Api.Client.ExecuteAsync(request);


            if (response.IsSuccessful)
            {
                App.Current.MainPage = new AdminPage();
            }
            else
            {
                // Handle error
            }
        }

        private async void OnPickImage()
        {
            try
            {
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    FileTypes = FilePickerFileType.Images,
                    PickerTitle = "Pick an image"
                });

                if (result != null)
                {
                    Image.Value = result.FullPath;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, e.g., user canceled picking an image
            }
        }
    }
}

