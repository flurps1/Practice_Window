using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Practice_Window.Core;

namespace Practice_Window;

public class BasePage<VM> : Page
where VM : BaseViewModel, new()
{
    #region Private members

    private VM mViewModel;
    

    #endregion
    
    #region Public Properties

    public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

    public PageAnimation PageUnLoadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

    public float SlideSeconds { get; set; } = 0.8f;

    public VM ViewModel
    {
        get => mViewModel;
        set
        {
            if (mViewModel == value)
                return;

            mViewModel = value;
            DataContext = mViewModel;
        }
    }
    
    #endregion

    #region Constructor

    public BasePage()
    {
        if (PageLoadAnimation != PageAnimation.None)
            Visibility = Visibility.Collapsed;
        Loaded += BasePage_LoadAsync;
        ViewModel = new VM();
    }
    #endregion

    #region Animationss for Load/Unload

    private async void BasePage_LoadAsync(object sender, RoutedEventArgs e)
    {
        await AnimateItAsync();
    }

    private async Task AnimateItAsync()
    {
        if (PageLoadAnimation == PageAnimation.None)
            return;
        switch (PageLoadAnimation)
        {
            case PageAnimation.SlideAndFadeInFromRight:
                await this.SlideAndFadeInFromRight(this.SlideSeconds);
                break;
        }
    }

    public async Task AnimateOutAsync()
    {
        if (PageUnLoadAnimation == PageAnimation.None)
            return;
        switch (PageUnLoadAnimation)
        {
            case PageAnimation.SlideAndFadeOutToLeft:
                await this.SlideAndFadeOutToLeft(SlideSeconds);
                break;
        }
    }

    #endregion
}