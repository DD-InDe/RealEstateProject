using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using RealtorSystemDesk.Database;
using RealtorSystemDesk.Models;
using RealtorSystemDesk.Services;

namespace RealtorSystemDesk.Pages.ClientManagePages;

public partial class AddContractPage : Page
{
    private NewContractModel _model;

    public AddContractPage(int clientId)
    {
        _model = new() { ClientId = clientId , DateCreate = DateTime.Today};
        InitializeComponent();

        DataContext = _model;
    }

    private void SaveButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            Db.Context.Contracts.Add(new()
            {
                ClientId = _model.ClientId,
                Type = _model.Type,
                DateCreate = DateOnly.FromDateTime(_model.DateCreate),
                ValidUntil = DateOnly.FromDateTime(_model.DateCreate.AddDays(_model.Days)),
                IsArchive = false
            });
            DatabaseSaveService.SaveWithMessage("Контракт добавлен!");
            NavigationService.GoBack();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageService.ShowError(exception);
        }
    }

    private async void AddContractPage_OnLoaded(object sender, RoutedEventArgs e)
    {
        try
        {
            TypeComboBox.ItemsSource = await Db.Context.ContractTypes.ToListAsync();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageService.ShowError(exception);
        }
    }
}