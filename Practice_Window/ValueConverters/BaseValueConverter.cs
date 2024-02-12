using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Practice_Window;

/// <summary>
/// Base converter которые позволяет напрямую использовать xaml
/// </summary>
/// <typeparam name="T">Type of this value converter
/// Тип который мы преобразуем</typeparam>
public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
    where T : class, new()
{
    private static T Conveter = null;

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return Conveter ?? (Conveter = new T());
    }

    #region Value converters method

    // Метод конвертирует предоставленные значение в другие
    public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);
    
    // Возвращает конвертированные данные
    public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);


    #endregion

}