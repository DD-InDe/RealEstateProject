using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using RealtorSystemDesk.Database;
using RealtorSystemDesk.Services;

namespace RealtorSystemDesk.Pages.ClientManagePages;

public partial class EditClientPage : Page
{
    private Client _client;

    public EditClientPage(Client client)
    {
        _client = client;
        InitializeComponent();
    }

    public EditClientPage()
    {
        _client = new() { Passport = new() };
        InitializeComponent();
    }

    private async void EditClientPage_OnLoaded(object sender, RoutedEventArgs e)
    {
        try
        {
            GenderComboBox.ItemsSource = await Db.Context.Genders.ToListAsync();

            DataContext = _client;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageService.ShowError(exception);
        }
    }

    private void SaveButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            string[] values =
            {
                _client.FirstName,
                _client.LastName,
                _client.MiddleName,
                _client.Passport.Number.ToString(),
                _client.Passport.Serial.ToString(),
                _client.Passport.IssuedBy,
                _client.Passport.IssuedDate.ToString(),
                _client.BirthDate.ToString()
            };
            if (values.All(c => !String.IsNullOrEmpty(c)) && _client.Gender != null)
            {
                if (_client.Passport.Serial.ToString().Length == 4 && _client.Passport.Number.ToString().Length == 6)
                {
                    if (_client.PassportId == 0)
                    {
                        _client.UserId = App.AuthorizedUser.Id;
                        Db.Context.Passports.Add(_client.Passport);
                        Db.Context.Clients.Add(_client);
                    }
                    else
                    {
                        Db.Context.Passports.Update(_client.Passport);
                        Db.Context.Clients.Update(_client);
                    }

                    DatabaseSaveService.SaveWithMessage();
                    NavigationService.GoBack();
                }
                else
                    MessageService.ShowInfo("Некорректные данные в поле \"Серия паспорта\" или \"Номер паспорта\"");
            }
            else
                MessageService.ShowInfo("Заполните все поля. Поля \"Почта\" и \"Телефон\" могут быть пустыми");
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageService.ShowError(exception);
        }
    }
}