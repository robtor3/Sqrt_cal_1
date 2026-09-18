using System.ComponentModel;

namespace Sqrt_cal_1
{
    public class LocalizationManager : INotifyPropertyChanged
    {
        public static LocalizationManager Instance { get; } = new LocalizationManager();

        private string _currentLanguage = "ru";

        private readonly Dictionary<string, Dictionary<string, string>> _strings = new()
        {
            ["ru"] = new Dictionary<string, string>
            {
                ["EnterNumber"] = "Введите число",
                ["AnswerPlaceholder"] = "Здесь будет ответ",
                ["UnknownSymbol"] = "Неизвестный символ в основании (используйте запятую)",
                ["SettingsTitle"] = "Настройки",
                ["Precision"] = "Точность вычислений",
                ["DecimalPlaces"] = "Знаков после запятой:",
                ["SwitchLanguage"] = "Switch to English",
                ["EnterRootDegree"] = "Введите степень корня",
                ["Calculate"] = "Вычислить",
                ["MainTitle"] = "Корень",
                ["ComplexTitle"] = "Комплексный корень",
                ["RootLabel"] = "Корень",
                ["EnterRealPart"] = "Введите действительную часть числа",
                ["EnterImagePart"] = "Введите мнимую часть числа",
            },
            ["en"] = new Dictionary<string, string>
            {
                ["EnterNumber"] = "Enter a number",
                ["AnswerPlaceholder"] = "The answer will appear here",
                ["UnknownSymbol"] = "Unknown character in base (use a comma)",
                ["SettingsTitle"] = "Settings",
                ["Precision"] = "Calculation precision",
                ["DecimalPlaces"] = "Decimal places:",
                ["SwitchLanguage"] = "Переключить на русский",
                ["EnterRootDegree"] = "Enter root degree",
                ["Calculate"] = "Calculate",
                ["MainTitle"] = "Root",
                ["ComplexTitle"] = "Complex root",
                ["RootLabel"] = "Root",
                ["EnterRealPart"] = "Enter the real part of the number",
                ["EnterImagePart"] = "Enter the imaginary part of the number",
            }
        };

        public string CurrentLanguage => _currentLanguage;

        public string this[string key]
        {
            get
            {
                if (_strings.TryGetValue(_currentLanguage, out var lang) &&
                    lang.TryGetValue(key, out var value))
                {
                    return value;
                }
                return key;
            }
        }

        public void ToggleLanguage()
        {
            _currentLanguage = _currentLanguage == "ru" ? "en" : "ru";

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}