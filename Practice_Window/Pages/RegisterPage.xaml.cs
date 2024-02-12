using System.Security;
using System.Windows.Controls;
using Practice_Window.Core;

namespace Practice_Window;

public partial class RegisterPage : BasePage<LoginViewModel>, IHavePassword
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    public SecureString SecurePassword => PasswordText.SecurePassword;

}