using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using RealtorSystemDesk.Database;
using RealtorSystemDesk.Pages.ClientManagePages;
using RealtorSystemDesk.Services;

namespace RealtorSystemDesk.Pages.ObjectManagePages;

public partial class ObjectInfoPage : Page
{
    private int _id;
    private RealEstateObject _object;

    public ObjectInfoPage(int id)
    {
        _id = id;
        InitializeComponent();
    }

    private async void ObjectInfoPage_OnLoaded(object sender, RoutedEventArgs e)
    {
        try
        {
            try
            {
                _object = await Db.Context.RealEstateObjects
                    .Include(c => c.Contract)
                    .Include(c => c.ObjectType)
                    .FirstAsync(c => c.ContractId == _id);

                DataContext = _object;
                LoadData();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                MessageService.ShowError(exception);
            }
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
            DocumentDataGrid.ItemsSource = null;
            DocumentDataGrid.ItemsSource = await Db.Context.RealEstateObjectDocuments.Include(c => c.Document)
                .Where(c => c.RealEstateObjectId == _object.ContractId).ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            MessageService.ShowError(e);
        }
    }

    private void EditButton_OnClick(object sender, RoutedEventArgs e) =>
        NavigationService.Navigate(new ObjectEditPage(_object));

    private void AddDocumentButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            int documentId = FileService.UploadFile();
            if (documentId != 0)
            {
                RealEstateObjectDocument objectDocument = new()
                {
                    RealEstateObjectId = _object.ContractId,
                    DocumentId = documentId
                };
                Db.Context.RealEstateObjectDocuments.Add(objectDocument);
                DatabaseSaveService.SaveWithMessage("Данные обновлены!");

                LoadData();
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageService.ShowError(exception);
        }
    }

    private void DocumentLoadButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            RealEstateObjectDocument document = (((Button)sender).DataContext as RealEstateObjectDocument)!;
            FileService.DownloadFile(document.Document.FileName);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageService.ShowError(exception);
        }
    }

    private void DocumentDeleteButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            Document document = ((RealEstateObjectDocument)((Button)sender).DataContext).Document!;
            FileService.DeleteFile(document);
            LoadData();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageService.ShowError(exception);
        }
    }

    private void CustomerButton_OnClick(object sender, RoutedEventArgs e) =>
        NavigationService.Navigate(new ClientInfoPage(_object.Contract.ClientId.Value));
}