using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using RealtorSystemDesk.Database;
using RealtorSystemDesk.Enums;
using RealtorSystemDesk.Pages.ObjectManagePages;
using RealtorSystemDesk.Services;
using Xceed.Document.NET;
using Xceed.Words.NET;

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
            _client = await Db
                .Context.Clients
                .Include(c => c.Passport)
                .Include(c => c.Gender)
                .FirstAsync(c => c.PassportId == _id);
            DataContext = _client;

            if (_client.IsArchive.Value)
            {
                EditButton.Visibility = Visibility.Collapsed;
                AddContractButton.Visibility = Visibility.Collapsed;
                AddDocumentButton.Visibility = Visibility.Collapsed;
                ArchiveButton.Visibility = Visibility.Collapsed;
            }

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
                await Db
                    .Context.Contracts
                    .Include(c => c.Type)
                    .Where(c => c.ClientId == _client.PassportId)
                    .ToListAsync();

            FileDataGrid.ItemsSource = null;
            FileDataGrid.ItemsSource =
                await Db
                    .Context.ClientFiles
                    .Include(c => c.File)
                    .Where(c => c.ClientId == _client.PassportId)
                    .ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            MessageService.ShowError(e);
        }
    }

    private void EditButton_OnClick(object sender, RoutedEventArgs e) =>
        NavigationService.Navigate(new EditClientPage(_client));

    private void PrintButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            SaveFileDialog dialog = new()
            {
                FileName = $"Отчет_по_клиентам_{DateTime.Today.ToString("dd-mm-yyyy")}", AddExtension = true,
                DefaultExt = "docx"
            };
            if (dialog.ShowDialog() == true)
            {
                using (var document = DocX.Load(dialog.FileName))
                {
                    Paragraph paragraph = document.InsertParagraph();
                    
                }
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageService.ShowError(exception);
        }
    }

    private void AddContractButton_OnClick(object sender, RoutedEventArgs e) =>
        NavigationService.Navigate(new AddContractPage(_client.PassportId));

    private void DocumentLoadButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            ClientFile file = (((Button)sender).DataContext as ClientFile)!;
            FileService.DownloadFile(file.File.FileName);
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
            File file = ((ClientFile)((Button)sender).DataContext).File!;
            FileService.DeleteFile(file);
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
            int fileId = FileService.UploadFile(FileOption.Document);
            if (fileId != 0)
            {
                ClientFile clientFile = new()
                {
                    ClientId = _client.PassportId,
                    FileId = fileId
                };
                Db.Context.ClientFiles.Add(clientFile);
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

    private void ArchiveClientButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            _client.IsArchive = true;
            DatabaseSaveService.SaveWithMessage("Клиент добавлен в архив");
            NavigationService.GoBack();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageService.ShowError(exception);
        }
    }

    private void NavigateToObject_OnClick(object sender, RoutedEventArgs e) =>
        NavigationService.Navigate(new ObjectInfoPage(((Contract)((Button)sender).DataContext).Id));
}