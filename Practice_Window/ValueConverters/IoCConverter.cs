using Practice_Window;
using System;
using System.Diagnostics;
using System.Globalization;
using Ninject;
using Practice_Window.Core;
using Practice_Window.Core.ioc;

namespace Practice_Window;
/// <summary>
/// Converts <see cref="IoCConverter"/> to actual view/page
/// </summary>
public class IoCConverter : BaseValueConverter<IoCConverter>
{


    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        switch ((string)value)
        {
            case nameof(ApplicationViewModel):
                return IoC.Kernel.Get<ApplicationViewModel>();
            default:
                Debugger.Break();
                return null;
        }
    }

    public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}