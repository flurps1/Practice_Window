using System.Security;

namespace Practice_Window.Core;

public interface IHavePassword
{
    /// <summary>
    /// The secure password
    /// </summary>
    SecureString SecurePassword { get; }
}