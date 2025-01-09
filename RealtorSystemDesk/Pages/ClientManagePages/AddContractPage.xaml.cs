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
    private RealEstateObject _estateObject;

    public AddContractPage(int clientId)
    {
        _model = new() { ClientId = clientId, DateCreate = DateTime.Today };
        _estateObject = new();

        InitializeComponent();

        DataContext = _model;
        ObjectPanel.DataContext = _estateObject;
    }

    private void SaveButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            if (_model.DateCreate != null && _model.Days > 0 && _model.Type != null)
            {
                Contract contract = new()
                {
                    ClientId = _model.ClientId,
                    Type = _model.Type,
                    DateCreate = DateOnly.FromDateTime(_model.DateCreate),
                    ValidUntil = DateOnly.FromDateTime(DateTime.Today.AddDays(_model.Days)),
                };
                if (TypeComboBox.SelectedIndex == 1)
                {
                    if (!String.IsNullOrEmpty(_estateObject.Address) &&
                        !String.IsNullOrEmpty(_estateObject.Description) &&
                        _estateObject.Floor > 0 && _estateObject.Price > 0 &&
                        _estateObject.FloorsCount > 0 && _estateObject.Square > 0 &&
                        _estateObject.BuildingYear > 0 && _estateObject.RoomsCount > 0 &&
                        _estateObject.ObjectType != null)
                    {
                        _estateObject.Contract = contract;
                        Db.Context.RealEstateObjects.Add(_estateObject);
                    }
                    else
                    {
                        MessageService.ShowInfo("Заполните все поля!");
                        return;
                    }
                }

                Db.Context.Contracts.Add(contract);

                DatabaseSaveService.SaveWithMessage("Данные добавлены");
                NavigationService.GoBack();
            }
            else
                MessageService.ShowInfo("Заполните все поля!");
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
            ObjectTypeComboBox.ItemsSource = await Db.Context.RealEstateObjectTypes.ToListAsync();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageService.ShowError(exception);
        }
    }

    private void TypeComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            ContractType type = (ContractType)TypeComboBox.SelectedItem;
            ObjectPanel.Visibility = type.Id == 2 ? Visibility.Visible : Visibility.Collapsed;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageService.ShowError(exception);
        }
    }
}