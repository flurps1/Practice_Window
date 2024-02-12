using System.Security;
using System.Windows.Controls;
using Practice_Window.Core;

namespace Practice_Window;

public partial class LoginPage : BasePage<LoginViewModel>, IHavePassword
{
    public LoginPage()
    {
        InitializeComponent();
    }

    public SecureString SecurePassword => PasswordText.SecurePassword;

}