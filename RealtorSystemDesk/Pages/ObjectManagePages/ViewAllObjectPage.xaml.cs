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
            bool showArchive = ArchiveCheckBox.IsChecked ?? false;
            RealEstateObjectType? type = TypeComboBox.SelectedItem as RealEstateObjectType;

            List<RealEstateObject> objects = await Db.Context.RealEstateObjects
                .Include(c => c.Contract)
                .Include(c => c.Contract.Client)
                .Include(c => c.ObjectType)
                .Where(c => c.Contract.Client.UserId == App.AuthorizedUser.Id &&
                            (c.Contract.Client.FirstName.ToLower().Contains(search) ||
                             c.Contract.Client.LastName.ToLower().Contains(search) ||
                             c.Contract.Client.MiddleName.ToLower().Contains(search) ||
                             (c.Description != null && c.Description.ToLower().Contains(search)) ||
                             (c.Notes != null && c.Notes.ToLower().Contains(search)) ||
                             (c.Address != null && c.Address.ToLower().Contains(search))))
                .ToListAsync();
            if (!showArchive) objects = objects.Where(c => c.IsArchive == false).ToList();
            if (type != null && type.Id != 0) objects = objects.Where(c => c.ObjectTypeId == type.Id).ToList();

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

    private void CheckBox_Check(object sender, RoutedEventArgs e) => LoadData();

    private void AddButton_OnClick(object sender, RoutedEventArgs e)
    {
        //todo: сделать навигацию на страницу добавления объекта
    }

    private void InfoButton_OnClick(object sender, RoutedEventArgs e)
        => NavigationService.Navigate(new ObjectInfoPage(((RealEstateObject)((Button)sender).DataContext).ContractId));

    private void TypeComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) => LoadData();
}