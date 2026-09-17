
using CommunityToolkit.Mvvm.ComponentModel;
using Sqrt_cal_1.Services;

namespace Sqrt_cal_1.ViewModels
{
    public partial class SettingsViewModel : ObservableObject
    {
        private readonly SettingsServices _settings;

        public SettingsViewModel(SettingsServices settings)
        {
            _settings = settings;
        }

        public double Precision
        {
            get => _settings.Precision;
            set
            {
                int v = (int)value;
                if (_settings.Precision == v) return;
                _settings.Precision = v;
                OnPropertyChanged();
            }
        }
    }
}
