using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using RealtorSystemDesk.Database;
using RealtorSystemDesk.Services;

namespace RealtorSystemDesk.Pages;

public partial class AccountManagePage : Page
{
    public class PageModel
    {
        public bool IsRegistration { get; set; }
        public User User { get; set; }
    }

    private PageModel _model;

    public AccountManagePage(bool isReg)
    {
        InitializeComponent();

        if (isReg)
        {
            Title = "Регистрация";
            BackButton.Visibility = Visibility.Visible;
        }

        _model = new() { IsRegistration = isReg, User = App.AuthorizedUser ?? new() };
        DataContext = _model;
    }

    private void SaveButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            string lastName = _model.User.LastName;
            string firstName = _model.User.FirstName;
            string middleName = _model.User.MiddleName;
            string login = _model.User.Login;
            string company = _model.User.CompanyName;
            string password = PasswordBox.Password;
            string repeatPassword = RepeatPasswordBox.Password;
            string[] values;
            if (_model.IsRegistration)
                values = [firstName, lastName, middleName, login, password, repeatPassword, company];
            else
                values = [firstName, lastName, middleName, login, company];
            bool isCorrect = values.All(c => !string.IsNullOrEmpty(c));

            if (isCorrect)
            {
                if (password.Equals(repeatPassword))
                {
                    string message = "Данные обновлены!";

                    if (_model.IsRegistration)
                    {
                        if (Db.Context.Users.FirstOrDefault(c => c.Login == login) == null)
                        {
                            _model.User.Password = password;
                            Db.Context.Users.Add(_model.User);
                            message = "Вы успешно зарегистрировались!";
                        }
                        else
                            MessageService.ShowInfo("Логин занят!");
                    }
                    else
                    {
                        _model.User.Password = !String.IsNullOrEmpty(password) ? password : _model.User.Password;
                        Db.Context.Users.Update(_model.User);
                    }

                    DatabaseSaveService.SaveWithMessage(message);
                }
                else
                    MessageService.ShowInfo("Пароли не совпадают!");
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

    private void BackButton_OnClick(object sender, RoutedEventArgs e) => NavigationService.GoBack();
}