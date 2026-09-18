using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Sqrt_cal_1.Services;

namespace Sqrt_cal_1.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly SettingsServices _settings;

        // Здесь храним "состояние" второй надписи, чтобы знать, что переводить при смене языка.
        // Возможные значения: "placeholder" (по умолчанию), "error" (ошибка), "value" (числовой ответ).
        private string _title2State = "placeholder";
        private string _title2RawValue = string.Empty;

        [ObservableProperty] private string title1;
        [ObservableProperty] private string title2;
        [ObservableProperty] private string userText = string.Empty;
        [ObservableProperty] private string userText1 = string.Empty;

        public MainViewModel(SettingsServices settings)
        {
            _settings = settings;

            // Проставляем начальные надписи на текущем языке
            RefreshLocalizedText();

            // Подписываемся на переключение языка: когда оно произойдёт — обновим надписи
            LocalizationManager.Instance.PropertyChanged += OnLanguageChanged;
        }

        private void OnLanguageChanged(object? sender, PropertyChangedEventArgs e)
        {
            RefreshLocalizedText();
        }

        // Обновляет все тексты в VM на текущий язык
        private void RefreshLocalizedText()
        {
            var loc = LocalizationManager.Instance;

            Title1 = loc["EnterNumber"];

            Title2 = _title2State switch
            {
                "placeholder" => loc["AnswerPlaceholder"],
                "error" => loc["UnknownSymbol"],
                _ => _title2RawValue   // уже посчитанный ответ — не трогаем
            };
        }

        [RelayCommand]
        private void Calculate()
        {
            bool okUserText = double.TryParse(UserText, out double osnovanie);
            bool okUserText1 = double.TryParse(UserText1, out double stepen);

            if (!okUserText || !okUserText1)
            {
                _title2State = "error";
                Title2 = LocalizationManager.Instance["UnknownSymbol"];
                return;
            }

            double root = Math.Pow(osnovanie, 1.0 / stepen);

            _title2State = "value";
            _title2RawValue = _settings.Format(root);
            Title2 = _title2RawValue;
        }
    }
}