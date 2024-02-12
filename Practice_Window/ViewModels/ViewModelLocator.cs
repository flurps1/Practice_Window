using System.Dynamic;
using Practice_Window.Core.ioc;

namespace Practice_Window;

public class ViewModelLocator
{
    public static ApplicationViewModel ApplicationViewModel => IoC.Get<ApplicationViewModel>();

    public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();
}