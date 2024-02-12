using Practice_Window;
using System;
using System.Diagnostics;
using System.Globalization;
using Practice_Window.Core;

namespace Practice_Window;
/// <summary>
/// Converts <see cref="ApplicationPage"/> to actual view/page
/// </summary>
public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
{


    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        switch ((ApplicationPage)value)
        {
            case ApplicationPage.Login:
                return new LoginPage();
            case ApplicationPage.Chat:
                return new ChatPage();
            case ApplicationPage.Register:
                return new ChatPage();
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