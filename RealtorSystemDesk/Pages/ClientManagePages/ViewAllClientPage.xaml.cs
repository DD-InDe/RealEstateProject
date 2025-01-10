using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RealtorSystemDesk.Database;
using RealtorSystemDesk.Pages.ClientManagePages;
using RealtorSystemDesk.Services;

namespace RealtorSystemDesk.Pages;

public partial class ViewAllClientPage : Page
{
    private List<Client> _clients = new();

    public ViewAllClientPage()
    {
        InitializeComponent();
    }

    private void SearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e) => LoadData();

    private void AddButton_OnClick(object sender, RoutedEventArgs e) =>
        NavigationService.Navigate(new EditClientPage());

    private void ViewAllClientPage_OnLoaded(object sender, RoutedEventArgs e)
    {
        try
        {
            LoadData();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageService.ShowError(exception);
        }
    }

    private async void LoadData()
    {
        try
        {
            string search = SearchTextBox.Text.ToLower();
            bool archive = ArchiveCheckBox.IsChecked ?? false;

            _clients = await Db.Context.Clients.Where(c =>
                    c.UserId == App.AuthorizedUser!.Id &&
                    (c.FirstName.ToLower().Contains(search) || c.LastName.ToLower().Contains(search) ||
                     (c.MiddleName != null && c.MiddleName.ToLower().Contains(search))))
                .ToListAsync();
            if (!archive)
                _clients = _clients.Where(c => c.IsArchive == false).ToList();

            ClientDataGrid.ItemsSource = null;
            ClientDataGrid.ItemsSource = _clients;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            MessageService.ShowError(e);
        }
    }

    private void InfoButton_OnClick(object sender, RoutedEventArgs e) =>
        NavigationService.Navigate(new ClientInfoPage(((Client)((Button)sender).DataContext).PassportId));

    private void CheckBox_ChangeCheck(object sender, RoutedEventArgs e) => LoadData();

    private void StatsButton_OnClick(object sender, RoutedEventArgs e) => NavigationService.Navigate(new StatsPage());
}