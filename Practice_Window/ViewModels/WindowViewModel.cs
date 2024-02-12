using System.Windows;
using System.Windows.Input;
using Practice_Window.Core;

namespace Practice_Window;
/// <summary>
/// The view model for a custom Winodw
/// </summary>
public class WindowViewModel : BaseViewModel
{
    #region Private member

    private Window mWindow;
    /// <summary>
    /// margin вокург на который падает тень и радиус окна
    /// </summary>
    private int mOuterMarginSize = 10;
    private int mWindowRadius = 10;

    #endregion

    #region Public members

    public double WindowMinimumWidth { get; set; } = 800;
    public double WindowMinimumHeight { get; set; } = 550;

    /// <summary>
    /// Resize Border Thickness
    /// </summary>
    public int ResizeBorder { get; set; } = 6;
    public Thickness ResizeBorderThickness => new(ResizeBorder + OuterMarginSize);

    public Thickness InnerContentPadding => new(ResizeBorder);

    /// <summary>
    /// margin вокург на который падает тень и радиус окна
    /// </summary>


    public int OuterMarginSize
    {
        get => mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize;
        set => mOuterMarginSize = value;
    }
    public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }

    public int WindowRadius
    {
        get { return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius; }
        set { mWindowRadius = value; }
    }
    public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

    public int TitleHeight { get; set; } = 42;

    public GridLength TitleHeightGridLength
    {
        get
        {
            return new GridLength(TitleHeight);
        }
    }


    #endregion

    #region Commands

    public ICommand MinimazeCommand { get; set; }
    public ICommand MaximizeCommand { get; set; }
    public ICommand CloseCommand { get; set; }
    public ICommand MenuCommand { get; set; }

    #endregion

    #region Construcotr

    public WindowViewModel(Window window)
    {
        mWindow = window;
        mWindow.StateChanged += (sender, e) =>
        {
            OnPropertyChanged(nameof(ResizeBorderThickness));
            OnPropertyChanged(nameof(OuterMarginSize));
            OnPropertyChanged(nameof(OuterMarginSizeThickness));
            OnPropertyChanged(nameof(WindowRadius));
            OnPropertyChanged(nameof(WindowCornerRadius));
        };

        MinimazeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
        MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
        CloseCommand = new RelayCommand(() => mWindow.Close());
        MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition()));

        //var resizer = new WindowResizer(mWindow);
    }

    #endregion

    #region Private helpers
    private Point GetMousePosition()
    {
        var position = Mouse.GetPosition(mWindow);
        return new Point(position.X + mWindow.Left, position.Y + mWindow.Top);
    }
    #endregion
}