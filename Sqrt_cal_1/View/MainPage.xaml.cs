using Sqrt_cal_1.ViewModels;

namespace Sqrt_cal_1
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}
