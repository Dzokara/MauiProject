namespace AndroidIspitniProjekat.Components
{
    public partial class JobComponent : ContentView
    {
        public static readonly BindableProperty PositionProperty =
            BindableProperty.Create(nameof(Position), typeof(string), typeof(JobComponent), string.Empty, BindingMode.TwoWay);

        public static readonly BindableProperty CompanyProperty =
            BindableProperty.Create(nameof(Company), typeof(string), typeof(JobComponent), string.Empty, BindingMode.TwoWay);

        public static readonly BindableProperty ImageProperty =
            BindableProperty.Create(nameof(Image), typeof(string), typeof(JobComponent), string.Empty, BindingMode.TwoWay);

        public static readonly BindableProperty RegionProperty =
            BindableProperty.Create(nameof(Region), typeof(string), typeof(JobComponent), string.Empty, BindingMode.TwoWay);

        public static readonly BindableProperty DeadlineProperty =
            BindableProperty.Create(nameof(Deadline), typeof(DateTime), typeof(JobComponent), DateTime.MinValue, BindingMode.OneWay);

        public static readonly BindableProperty SalaryProperty =
            BindableProperty.Create(nameof(Salary), typeof(decimal), typeof(JobComponent), 0m, BindingMode.OneWay);

        public static readonly BindableProperty RemoteProperty =
            BindableProperty.Create(nameof(Remote), typeof(string), typeof(JobComponent), string.Empty, BindingMode.OneWay);

        public static readonly BindableProperty DescriptionProperty =
            BindableProperty.Create(nameof(Description), typeof(string), typeof(JobComponent), string.Empty, BindingMode.OneWay);

        public static readonly BindableProperty TypeProperty =
            BindableProperty.Create(nameof(Type), typeof(string), typeof(JobComponent), string.Empty, BindingMode.OneWay);

        public JobComponent()
        {
            InitializeComponent();
        }

        public string Position
        {
            get => (string)GetValue(PositionProperty);
            set => SetValue(PositionProperty, value);
        }

        public string Company
        {
            get => (string)GetValue(CompanyProperty);
            set => SetValue(CompanyProperty, value);
        }

        public string Image
        {
            get => (string)GetValue(ImageProperty);
            set => SetValue(ImageProperty, value);
        }

        public string Region
        {
            get => (string)GetValue(RegionProperty);
            set => SetValue(RegionProperty, value);
        }

        public DateTime Deadline
        {
            get => (DateTime)GetValue(DeadlineProperty);
            set => SetValue(DeadlineProperty, value);
        }

        public decimal Salary
        {
            get => (decimal)GetValue(SalaryProperty);
            set => SetValue(SalaryProperty, value);
        }

        public string Remote
        {
            get => (string)GetValue(RemoteProperty);
            set => SetValue(RemoteProperty, value);
        }

        public string Description
        {
            get => (string)GetValue(DescriptionProperty);
            set => SetValue(DescriptionProperty, value);
        }

        public string Type
        {
            get => (string)GetValue(TypeProperty);
            set => SetValue(TypeProperty, value);
        }
    }
}
