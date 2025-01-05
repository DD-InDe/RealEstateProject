using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RealtorSystemDesk.Database;
using RealtorSystemDesk.Services;

namespace RealtorSystemDesk.Pages;

public partial class ViewAllClientPage : Page
{
    private List<Client> _clients = new();

    public ViewAllClientPage()
    {
        InitializeComponent();

        ClientDataGrid.ItemsSource = _clients;
    }

    private void SearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e) => LoadData();

    private void AddButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageService.ShowError(exception);
        }
    }

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
            _clients.Clear();
            _clients = await Db.Context.Clients.Where(c=>c.UserId == App.AuthorizedUser!.Id).ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            MessageService.ShowError(e);
        }
    }
}