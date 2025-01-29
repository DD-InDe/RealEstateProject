using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using RealtorSystemDesk.Database;
using RealtorSystemDesk.Pages.ObjectManagePages;
using RealtorSystemDesk.Services;

namespace RealtorSystemDesk.Pages;

public partial class ViewAllObjectPage : Page
{
    public ViewAllObjectPage()
    {
        InitializeComponent();
    }

    private async void ViewAllObjectPage_OnLoaded(object sender, RoutedEventArgs e)
    {
        try
        {
            List<RealEstateObjectType> types = new() { new() { Name = "Все" } };
            types.AddRange(await Db.Context.RealEstateObjectTypes.ToListAsync());
            TypeComboBox.ItemsSource = types;

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
            RealEstateObjectType? type = TypeComboBox.SelectedItem as RealEstateObjectType;

            List<RealEstateObject> objects = await Db.Context.RealEstateObjects
                .Include(c => c.Contract)
                .Include(c => c.Contract.Client)
                .Include(c => c.Type)
                .Where(c =>
                    c.Contract.Client.FirstName.ToLower().Contains(search) ||
                    c.Contract.Client.LastName.ToLower().Contains(search) ||
                    c.Contract.Client.MiddleName.ToLower().Contains(search) ||
                    (c.Address != null && c.Address.ToLower().Contains(search)) ||
                    (c.CadastralNumber != null && c.CadastralNumber.ToLower().Contains(search)))
                .ToListAsync();
            if (type != null && type.Id != 0) objects = objects.Where(c => c.TypeId == type.Id).ToList();

            ObjectDataGrid.ItemsSource = null;
            ObjectDataGrid.ItemsSource = objects;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            MessageService.ShowError(e);
        }
    }

    private void SearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e) => LoadData();

    private void InfoButton_OnClick(object sender, RoutedEventArgs e)
        => NavigationService.Navigate(
            new ObjectInfoPage(((RealEstateObject)((Button)sender).DataContext).ContractId.Value));

    private void TypeComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) => LoadData();
}