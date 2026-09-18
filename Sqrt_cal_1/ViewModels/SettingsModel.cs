
using CommunityToolkit.Mvvm.ComponentModel;
using Sqrt_cal_1.Services;

namespace Sqrt_cal_1.ViewModels;
public partial class SettingsViewModel : ObservableObject // объявляем класс SettingsViewModel, наследуем ObservableObject чтобы класс мог уведомить подписанные компоненты об изменениях в своих свойствах
    {
        private readonly SettingsServices _settings; // ссылка на сервис настроек

        public SettingsViewModel(SettingsServices settings) // внедрение зависимости через конструктор
        {
            _settings = settings;
        }

        public double Precision
        {
            get => _settings.Precision; // возвращает текущее значение точности из сервиса настроек
            set
            {
                int v = (int)value; //  UI присылает double (Stepper), приводим к int для сервиса
                if (_settings.Precision == v) return; // если новое значение совпадает со старым просто выводим его
                _settings.Precision = v; // присваиваем новое значение точности
                OnPropertyChanged(); // сообщаем UI что значение изменилось
            }
        }
    }

