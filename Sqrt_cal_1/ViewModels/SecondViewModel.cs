
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Sqrt_cal_1.Services;
using System.Numerics;

namespace Sqrt_cal_1.ViewModels
{
    public partial class SecondViewModel : ObservableObject
    {
        private readonly SettingsServices _settings;

        public SecondViewModel(SettingsServices settings)
        {
            _settings = settings;
        }
        [ObservableProperty] private string userText1 = string.Empty;
        [ObservableProperty] private string real = string.Empty;
        [ObservableProperty] private string image = string.Empty;
        [ObservableProperty] private string title2 = "Здесь будет ответ";

        [RelayCommand]
        private void Calculate()
        {
            bool okUserText = double.TryParse(real, out double osnovanieReal);
            bool okUserText1 = double.TryParse(image, out double osnovanieImage);
            bool okUserText2 = int.TryParse(UserText1, out int stepen);
            
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
            if (!okUserText2)
            {
                Title2 = "Неизвестный символ в основании (используйте запятую)";
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
            for (int k = 0; k < stepen; k++)
            {
                sb.AppendLine($"Корень {k + 1}: {_settings.FormatComplex(result[k])}");
            }
            Title2 = sb.ToString().TrimEnd();


        }



    }
        
}
