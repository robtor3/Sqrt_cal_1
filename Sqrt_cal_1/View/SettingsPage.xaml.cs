using Sqrt_cal_1.ViewModels;

namespace Sqrt_cal_1;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
    private void OnSwitchLanguageClicked(object sender, EventArgs e)
    {
        LocalizationManager.Instance.ToggleLanguage();
    }
}