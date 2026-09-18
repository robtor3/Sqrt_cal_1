using System.ComponentModel;
using System.Numerics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Sqrt_cal_1.Services;

namespace Sqrt_cal_1.ViewModels
{
    public partial class SecondViewModel : ObservableObject
    {
        private readonly SettingsServices _settings;

        // Память для второй надписи, как и в MainViewModel
        private string _title2State = "placeholder";
        private string _title2RawValue = string.Empty;

        [ObservableProperty] private string userText1 = string.Empty;
        [ObservableProperty] private string real = string.Empty;
        [ObservableProperty] private string image = string.Empty;
        [ObservableProperty] private string title2 = string.Empty;

        public SecondViewModel(SettingsServices settings)
        {
            _settings = settings;

            RefreshLocalizedText();
            LocalizationManager.Instance.PropertyChanged += OnLanguageChanged;
        }

        private void OnLanguageChanged(object? sender, PropertyChangedEventArgs e)
        {
            RefreshLocalizedText();
        }

        private void RefreshLocalizedText()
        {
            var loc = LocalizationManager.Instance;
            Title2 = _title2State switch
            {
                "placeholder" => loc["AnswerPlaceholder"],
                "error" => loc["UnknownSymbol"],
                _ => _title2RawValue
            };
        }

        [RelayCommand]
        private void Calculate()
        {
            bool okUserText = double.TryParse(real, out double osnovanieReal);
            bool okUserText1 = double.TryParse(image, out double osnovanieImage);
            bool okUserText2 = int.TryParse(UserText1, out int stepen);

            if (!okUserText|| !okUserText1|| !okUserText2);

            {
                _title2State = "error";
                Title2 = LocalizationManager.Instance["UnknownSymbol"];
                return;
            }

            var result = new Complex[stepen];

            double r = Math.Sqrt(osnovanieReal * osnovanieReal + osnovanieImage * osnovanieImage);
            double theta = Math.Atan2(osnovanieImage, osnovanieReal);
            double rootR = Math.Pow(r, 1.0 / stepen);

            for (int k = 0; k < stepen; k++)
            {
                double angle = (theta + 2 * Math.PI * k) / stepen;
                double re = rootR * Math.Cos(angle);
                double im = rootR * Math.Sin(angle);
                result[k] = new Complex(re, im);
            }

            var sb = new System.Text.StringBuilder();
            string rootLabel = LocalizationManager.Instance["RootLabel"];
            for (int k = 0; k < stepen; k++)
            {
                sb.AppendLine($"{rootLabel} {k + 1}: {_settings.FormatComplex(result[k])}");
            }

            _title2State = "value";
            _title2RawValue = sb.ToString().TrimEnd();
            Title2 = _title2RawValue;
        }
    }
}
