using AndroidIspitniProjekat.Business.DTO;
using AndroidIspitniProjekat.Common;
using AndroidIspitniProjekat.Validators;
using FluentValidation;
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

namespace AndroidIspitniProjekat.ViewModels
{
    public class AdminJobsViewModel
    {
        public ObservableCollection<CompanyDto> Companies { get; set; } = new ObservableCollection<CompanyDto>();
        public ObservableCollection<PositionDto> Positions { get; set; } = new ObservableCollection<PositionDto>();
        public ObservableCollection<RegionDto> Regions { get; set; } = new ObservableCollection<RegionDto>();
        public ObservableCollection<TypeDto> Types { get; set; } = new ObservableCollection<TypeDto>();
        public ObservableCollection<RemoteDto> Remote { get; set; } = new ObservableCollection<RemoteDto>();
        public Prop<PositionDto> SelectedPosition { get; set; } = new Prop<PositionDto>();
        public Prop<CompanyDto> SelectedCompany { get; set; } = new Prop<CompanyDto>();
        public Prop<RegionDto> SelectedRegion { get; set; } = new Prop<RegionDto>();
        public Prop<TypeDto> SelectedType { get; set; } = new Prop<TypeDto>();
        public Prop<RemoteDto> SelectedRemote { get; set; } = new Prop<RemoteDto>();

        public Prop<string> Description { get; set; } = new Prop<string>();
        public Prop<decimal> Salary { get; set; } = new Prop<decimal>();
        public Prop<DateTime> Deadline { get; set; } = new Prop<DateTime>();
        public Prop<bool> ButtonEnabled { get; set; } = new Prop<bool>();
        public DateTime MinimumDate => DateTime.Now.AddDays(1);
        public ICommand SubmitCommand { get; }

        public AdminJobsViewModel()
        {
            LoadData();
            LoadTypes();
            LoadRemoteOptions();

            SubmitCommand = new Command(async () => await ExecuteSubmitCommand());

            SelectedPosition.OnChange = Validate;
            SelectedType.OnChange = Validate;
            SelectedCompany.OnChange = Validate;
            SelectedRemote.OnChange = Validate;
            SelectedRegion.OnChange = Validate;
            Deadline.OnChange = Validate;
            Description.OnChange = Validate;
            Salary.OnChange = Validate;
            ButtonEnabled.Value = true;
        }

        private void LoadData()
        {
            LoadCompanies();
            LoadPositions();
            LoadRegions();
            
        }

        private void LoadCompanies()
        {
            string token = SecureStorage.Default.GetUser().Token;

            RestRequest request = new RestRequest("Company");

            var response = Api.Client.Execute<ApiResponse<CompanyDto>>(request);

            var apiResponse = JsonConvert.DeserializeObject<ApiResponse<CompanyDto>>(response.Content);
            var companies = apiResponse?.Data;

            if (companies != null)
            {
                Companies.Clear();
                foreach (var cmp in companies)
                {
                    Companies.Add(cmp);
                }
            }
        }

        private void LoadPositions()
        {
            string token = SecureStorage.Default.GetUser().Token;

            RestRequest request = new RestRequest("Positions");

            var response = Api.Client.Execute<ApiResponse<PositionDto>>(request);

            var apiResponse = JsonConvert.DeserializeObject<ApiResponse<PositionDto>>(response.Content);
            var positions = apiResponse?.Data;

            if (positions != null)
            {
                Positions.Clear();
                foreach (var pos in positions)
                {
                    Positions.Add(pos);
                }
            }
        }

        private void LoadRegions()
        {
            string token = SecureStorage.Default.GetUser().Token;

            RestRequest request = new RestRequest("Region");

            var response = Api.Client.Execute<ApiResponse<RegionDto>>(request);

            var apiResponse = JsonConvert.DeserializeObject<ApiResponse<RegionDto>>(response.Content);
            var regions = apiResponse?.Data;

            if (regions != null)
            {
                Regions.Clear();
                foreach (var reg in regions)
                {
                    Regions.Add(reg);
                }
            }
        }
        private void LoadTypes()
        {
           
            Types.Clear();
            Types.Add(new TypeDto { Id = 3, Name = "Full Time" });
            Types.Add(new TypeDto { Id = 4, Name = "Part Time" });
        }

        private void LoadRemoteOptions()
        {
         
            Remote.Clear();
            Remote.Add(new RemoteDto { Id = 1, Name = "Home" });
            Remote.Add(new RemoteDto { Id = 2, Name = "Office" });
        }


        private void Validate()
        {
            JobInsertValidator validator = new JobInsertValidator();
            ValidationResult result = validator.Validate(this);

            SelectedPosition.Error = result.GetError("SelectedPosition");
            SelectedCompany.Error = result.GetError("SelectedCompany");
            SelectedType.Error = result.GetError("SelectedType");
            SelectedRemote.Error = result.GetError("SelectedRemote");
            SelectedRegion.Error = result.GetError("SelectedRegion");
            Salary.Error = result.GetError("Salary");
            Description.Error = result.GetError("Description");
            Deadline.Error = result.GetError("Deadline");


            ButtonEnabled.Value = result.IsValid;
        }

        private async Task ExecuteSubmitCommand()
        {
            var positionId = SelectedPosition.Value.Id;
            var companyId = SelectedCompany.Value.Id;
            var technologyIds = new List<int> { 1 };
            var regionId = SelectedRegion.Value.Id;
            var typeId = SelectedType.Value.Id;
            var remoteId = SelectedRemote.Value.Id;
            var description = Description.Value;
            var salary = Salary.Value;
            var deadline = Deadline.Value;
            var benefitIds = new List<int> { 1 };
            var categoryIds = new List<int> { 1 };
            var request = new RestRequest("Job", Method.Post);
            request.AddJsonBody(new {positionId,companyId,technologyIds,regionId,typeId,description, salary,benefitIds,categoryIds,deadline,remoteId });

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
    }
}

