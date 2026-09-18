using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Sqrt_cal_1.Services;
namespace Sqrt_cal_1.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly SettingsServices _settings;

        public MainViewModel(SettingsServices settings) 
        {
            _settings = settings;
        }
        [ObservableProperty] private string title1 = "Введите число";
        [ObservableProperty] private string title2 = "Здесь будет ответ";
        [ObservableProperty] private string userText = string.Empty;
        [ObservableProperty] private string userText1 = string.Empty;

        [RelayCommand]
        private void Calculate()
        {
            bool okUserText = double.TryParse(UserText, out double osnovanie);
            bool okUserText1 = double.TryParse(UserText1, out double stepen);

            if (!okUserText)
            {
                Title2 = "Неизвестный символ в основании (используйте запятую)";
                return;
            }
            if (!okUserText1)
            {
                Title2 = "Неизвестный символ в основании (используйте запятую)";
                return;
            }
            double root = Math.Pow(osnovanie, 1.0 / stepen);
            Title2 = _settings.Format(root);

        }
    }
}
