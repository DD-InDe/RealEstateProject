using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using RealtorSystemDesk.Database;
using RealtorSystemDesk.Services;

namespace RealtorSystemDesk.Pages.ClientManagePages;

public partial class ClientInfoPage : Page
{
    private Client _client;
    private int _id;

    public ClientInfoPage(int id)
    {
        _id = id;
        InitializeComponent();
    }

    private async void ClientInfoPage_OnLoaded(object sender, RoutedEventArgs e)
    {
        try
        {
            _client = await Db.Context.Clients
                .Include(c => c.Passport)
                .Include(c => c.Gender)
                .FirstAsync(c => c.PassportId == _id);
            DataContext = _client;

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
            ContractDataGrid.ItemsSource = null;
            ContractDataGrid.ItemsSource =
                await Db.Context.Contracts
                    .Include(c => c.Type)
                    .Where(c => c.ClientId == _client.PassportId).ToListAsync();

            DocumentDataGrid.ItemsSource = null;
            DocumentDataGrid.ItemsSource =
                await Db.Context.ClientDocuments
                    .Include(c => c.Document)
                    .Where(c => c.ClientId == _client.PassportId).ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            MessageService.ShowError(e);
        }
    }

    private void EditButton_OnClick(object sender, RoutedEventArgs e)
    {
        //todo: сделать навигацию на страницу редактирования
    }

    private void PrintButton_OnClick(object sender, RoutedEventArgs e)
    {
        //todo: сделать печать контрактов
    }

    private void AddContractButton_OnClick(object sender, RoutedEventArgs e) =>
        NavigationService.Navigate(new AddContractPage(_client.PassportId));

    private void ArchiveButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            Contract contract = (((Button)sender).DataContext as Contract)!;
            contract.IsArchive = true;
            Db.Context.Contracts.Update(contract);
            DatabaseSaveService.SaveWithMessage("Договор помечен как архив");

            LoadData();
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
            ClientDocument document = (((Button)sender).DataContext as ClientDocument)!;
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
            Document document = ((ClientDocument)((Button)sender).DataContext).Document!;
            FileService.DeleteFile(document);
            LoadData();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageService.ShowError(exception);
        }
    }

    private void DocumentAddButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            int documentId = FileService.UploadFile();
            if (documentId != 0)
            {
                ClientDocument clientDocument = new()
                {
                    ClientId = _client.PassportId,
                    DocumentId = documentId
                };
                Db.Context.ClientDocuments.Add(clientDocument);
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
}