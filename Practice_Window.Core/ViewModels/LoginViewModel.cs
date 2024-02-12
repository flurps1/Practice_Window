using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Practice_Window.Core.ioc;

namespace Practice_Window.Core
{
    /// <summary>
    /// The View Model for a login screen
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// A flag indicating if the login command is running
        /// </summary>
        public SecureString Password { get; set; }

        public bool LoginIsRunning { get; set; }
        #endregion

        #region Commands

        /// <summary>
        /// The command to login and register
        /// </summary>
        public ICommand LoginCommand { get; set; }
            
        public ICommand RegisterCommand { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public LoginViewModel()
        {
            // Create commands
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await LoginAsync(parameter));
            RegisterCommand = new RelayCommand((async () => await RegisterAsync()));
        }

        #endregion

        /// <summary>
        /// Attempts to log the user in
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/> passed in from the view for the users password</param>
        /// <returns></returns>

        public async Task LoginAsync(object parameter)
        {
            await Task.Delay(5000);
            var email = this.Email;
            var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
        }
        
        public async Task RegisterAsync()
        {
            // Go to register page?
            IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.Register;
            //((WindowViewModel) ((MainWindow) Application.Current.MainWindow).DataContext).CurrentPage =
            //  ApplicationPage.Register;

            await Task.Delay(1);
        }
    }
}
