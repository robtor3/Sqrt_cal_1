using Sqrt_cal_1.ViewModels;

namespace Sqrt_cal_1;

public partial class SecondPage : ContentPage
{
	public SecondPage(SecondViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}