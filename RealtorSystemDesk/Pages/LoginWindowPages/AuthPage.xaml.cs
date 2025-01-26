using System.Windows;
using System.Windows.Controls;
using RealtorSystemDesk.Database;
using RealtorSystemDesk.Services;

namespace RealtorSystemDesk.Pages;

public partial class AuthPage : Page
{
    private RealtorSystemDbContext _context;

    public AuthPage()
    {
        _context = new();
        InitializeComponent();
    }

    private void LoginButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;

            if (!String.IsNullOrEmpty(login) && !String.IsNullOrEmpty(password))
            {
                User? user = _context.Users.FirstOrDefault(c => c.Login == login && c.Password == password);
                if (user != null)
                {
                    App.AuthorizedUser = user;
                    MainWindow window = new();
                    // LoginWindow loginWindow = (Application.Current.MainWindow as LoginWindow)!;
                    window.Show();
                    Application.Current.MainWindow = window;

                    // loginWindow.Close();
                }
                else
                    MessageService.ShowInfo("Пользователь не найден!");
            }
            else
                MessageService.ShowInfo("Поля не могут быть пустыми!");
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageService.ShowError(exception);
        }
    }

    private void RegButton_OnClick(object sender, RoutedEventArgs e) =>
        NavigationService.Navigate(new AccountManagePage(true));
}