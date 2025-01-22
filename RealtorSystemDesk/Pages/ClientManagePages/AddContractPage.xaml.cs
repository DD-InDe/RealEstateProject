using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;
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
                    UserId = App.AuthorizedUser.Id,
                    Type = _model.Type,
                    DateCreate = DateOnly.FromDateTime(_model.DateCreate),
                    ValidUntil = DateOnly.FromDateTime(DateTime.Today.AddDays(_model.Days)),
                };
                _estateObject.Contract = contract;

                if (TypeComboBox.SelectedIndex == 1 && AddObject())
                {
                    Db.Context.Contracts.Add(contract);

                    DatabaseSaveService.SaveWithMessage("Данные добавлены");
                    NavigationService.GoBack();
                }
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

    private bool AddObject()
    {
        try
        {
            if (!String.IsNullOrEmpty(_estateObject.Address) &&
                !String.IsNullOrEmpty(_estateObject.CadastralNumber) &&
                _estateObject is { Square: > 0, Price: > 0, RoomsCount: > 0, Type: not null })
            {
                if (Db.Context.RealEstateObjects.Find(_estateObject.CadastralNumber) != null)
                {
                    MessageService.ShowError(new Exception("Объект с таким кадастровым номером уже существует!"));
                    return false;
                }

                switch (_estateObject.Type.Id)
                {
                    case 1:
                        if (_estateObject is { FloorsCount: > 0, PlotSquare: > 0 } &&
                            !String.IsNullOrEmpty(_estateObject.Material))
                        {
                            Db.Context.RealEstateObjects.Add(_estateObject);
                            return true;
                        }

                        break;
                    case 2:
                        if (_estateObject is { Floor: > 0, Class: not null })
                        {
                            Db.Context.RealEstateObjects.Add(_estateObject);
                            return true;
                        }

                        break;
                }
            }

            MessageService.ShowInfo("Заполните все поля");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            MessageService.ShowError(e);
        }

        return false;
    }


    private async void AddContractPage_OnLoaded(object sender, RoutedEventArgs e)
    {
        try
        {
            TypeComboBox.ItemsSource = await Db.Context.ContractTypes.ToListAsync();
            ObjectTypeComboBox.ItemsSource = await Db.Context.RealEstateObjectTypes.ToListAsync();
            ClassComboBox.ItemsSource = Db.Context.RealEstateObjectClasses.ToList();
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

    private void ObjectTypeComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        RealEstateObjectType type = (RealEstateObjectType)ObjectTypeComboBox.SelectedItem;
        if (type.Id == 1)
        {
            HousePanel.Visibility = Visibility.Visible;
            ApartmentPanel.Visibility = Visibility.Collapsed;
        }
        else
        {
            HousePanel.Visibility = Visibility.Collapsed;
            ApartmentPanel.Visibility = Visibility.Visible;
        }
    }
}