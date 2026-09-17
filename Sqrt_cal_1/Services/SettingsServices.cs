using CommunityToolkit.Mvvm.ComponentModel;
using Sqrt_cal_1.Services;
using System.Numerics;
namespace Sqrt_cal_1.Services;

public partial class SettingsServices : ObservableObject
{
    [ObservableProperty]
    private int precision = 2;

    [ObservableProperty]
    private bool useInvariantCulture = false;


    public string Format(double value)
        => value.ToString("F" + Precision,
            System.Globalization.CultureInfo.InvariantCulture);

    public string FormatComplex(Complex c)
    {
        if (Math.Abs(c.Imaginary) < 1e-12)
            return Format(c.Real);

        string re = Format(c.Real);
        string im = Format(Math.Abs(c.Imaginary));
        string sign = c.Imaginary < 0 ? "-" : "+";

        if (Math.Abs(c.Real) < 1e-12)
            return (c.Imaginary < 0 ? "-" : "") + im + "i";

        return $"{re} {sign} {im}i";
    }
}