using System;
using System.Windows;

namespace Practice_Window
{
    public abstract class BaseAttachedProperty<Parent, Property>
        where Parent : BaseAttachedProperty<Parent, Property>, new()
    {
        #region Public events

        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };

        #endregion

        #region Public properties

        public static Parent Instance { get; set; } = new Parent();

        #endregion

        #region Attached property definitions

        /// <summary>
        /// atached properties for this class
        /// </summary>
        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached("Value",
            typeof(Property), typeof(BaseAttachedProperty<Parent, Property>),
            new PropertyMetadata(new PropertyChangedCallback(OnValuePropertyChanged)));

        /// <summary>
        /// callback event when <see cref="ValueProperty"/> is changed
        /// </summary>
        /// <param name="d">UI element that was changed</param>
        /// <param name="e">Argument for event</param>
        /// <exception cref="NotImplementedException"></exception>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Instance.ValueChanged(d, e);
            Instance.OnValueChanged(d, e);
        }
        //get attached property
        public static Property GetValue(DependencyObject d) => (Property)d.GetValue(ValueProperty);
        //get attached property
        public static void SetValue(DependencyObject d, Property value) => d.SetValue(ValueProperty, value);

        #endregion

        #region Event Methods

        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { }

        #endregion
    }
}
