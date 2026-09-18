using CommunityToolkit.Mvvm.ComponentModel;
using Sqrt_cal_1.Services;
using System.Numerics;
namespace Sqrt_cal_1.Services;

public partial class SettingsServices : ObservableObject // объявляем класс SettingsServices, наследуем ObservableObject чтобы класс мог уведомить подписанные на него компоненты об изменениях в своих свойств
{
    [ObservableProperty]
    private int precision = 2; // поле с точностью по умолчанию

    //[ObservableProperty]
    //private bool useInvariantCulture = false;

    public string Format(double value)
        => value.ToString("F" + Precision,
            System.Globalization.CultureInfo.InvariantCulture); // форматирование (для действительных чисел) через fixed point формата "F" + кол-во знаков после запятой, Precision, берётся из свойства, сгенерированного [ObservableProperty]

    public string FormatComplex(Complex c)
    {
        if (Math.Abs(c.Imaginary) < 1e-12) // если мнимая часть комплексного числа очень мала, считаем её нулём; форматируем и возвращаем только действительную часть
            return Format(c.Real);

        string re = Format(c.Real); // форматируем действ часть
        string im = Format(Math.Abs(c.Imaginary)); // форматируем мнимую часть (по модулю)
        string sign = c.Imaginary < 0 ? "-" : "+"; // знак перед мнимой частью компл числа

        if (Math.Abs(c.Real) < 1e-12)
            return (c.Imaginary < 0 ? "-" : "") + im + "i"; // если действительная часть комплексного числа очень мала, считаем её нулём; форматируем и возвращаем только мнимую часть

        return $"{re} {sign} {im}i"; // возвращаем в формате действ часть +- мнимая часть
    }
}