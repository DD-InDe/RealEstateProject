using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using RealtorSystemDesk.Database;
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
            ContractListView.ItemsSource = null;
            ContractListView.ItemsSource =
                await Db
                    .Context.Contracts
                    .Include(c => c.Type)
                    .Where(c => c.ClientId == _client.PassportId && c.UserId == App.AuthorizedUser.Id)
                    .ToListAsync();

            FileDataGrid.ItemsSource = null;
            FileDataGrid.ItemsSource =
                await Db
                    .Context.ClientFiles
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
            Contract contract = ((Button)sender).DataContext as Contract;
            if (contract.TypeId == 2)
                contract = Db.Context.Contracts.Include(c => c.Client)
                    .Include(c => c.RealEstateObject)
                    .Include(c => c.RealEstateObject.Type)
                    .Include(c => c.Client.Passport)
                    .First(c => c.Id == contract.Id);
            else
                contract = Db.Context.Contracts.Include(c => c.Client)
                    .Include(c => c.Client.Passport)
                    .First(c => c.Id == contract.Id);

            SaveFileDialog dialog = new()
            {
                FileName =
                    $"договор_{contract.Client.LastName}_{contract.DateCreate.Value.ToDateTime(new()).ToString("dd-mm-yyyy")}",
                AddExtension = true,
                DefaultExt = "docx"
            };
            if (dialog.ShowDialog() == true)
            {
                var document = contract.TypeId == 2
                    ? DocX.Load(@"../../../resources/sell_template.docx")
                    : DocX.Load(@"../../../resources/buy_template.docx");

                List<Bookmark> bookmarks = document.GetBookmarks().ToList();
                bookmarks.Find(c => c.Name == "CONTRACT_ID").SetText(contract.Id.ToString());
                bookmarks.Find(c => c.Name == "DATE_DAY").SetText(contract.DateCreate.Value.Day.ToString());
                bookmarks.Find(c => c.Name == "DATE_MONTH").SetText(GetMonthName(contract.DateCreate.Value.Month));
                bookmarks.Find(c => c.Name == "DATE_YEAR").SetText(contract.DateCreate.Value.Year.ToString());
                bookmarks.Find(c => c.Name == "ORG_NAME").SetText(App.AuthorizedUser.LastName);
                bookmarks.Find(c => c.Name == "CLIENT_NAME").SetText(contract.Client.FullName);
                bookmarks.Find(c => c.Name == "CLIENT_PASS_S").SetText(contract.Client.Passport.Serial.ToString());
                bookmarks.Find(c => c.Name == "CLIENT_PASS_N").SetText(contract.Client.Passport.Number.ToString());
                bookmarks.Find(c => c.Name == "CLIENT_PASS_BY").SetText(contract.Client.Passport.IssuedBy);
                bookmarks.Find(c => c.Name == "CLIENT_PASS_DATE")
                    .SetText(contract.Client.Passport.IssuedDate.Value.ToString());
                bookmarks.Find(c => c.Name == "CLIENT_PHONE").SetText(contract.Client.Phone);
                bookmarks.Find(c => c.Name == "USER_NAME").SetText(
                    $"{App.AuthorizedUser.LastName} {App.AuthorizedUser.FirstName} {App.AuthorizedUser.MiddleName}");
                bookmarks.Find(c => c.Name == "CONTRACT_DATE_VALID")
                    .SetText(contract.ValidUntil.Value.ToDateTime(new()).ToString("dd.MM.yy"));
                bookmarks.Find(c => c.Name == "REWARD").SetText(contract.RealtorReward);

                if (contract.TypeId == 2)
                {
                    bookmarks.Find(c => c.Name == "OBJECT_TYPE")
                        .SetText(contract.RealEstateObject.Type.Name);
                    bookmarks.Find(c => c.Name == "OBJECT_ADDRESS").SetText(contract.RealEstateObject.Address);
                    bookmarks.Find(c => c.Name == "OBJECT_PRICE").SetText(contract.RealEstateObject.Price.ToString());
                }

                document.SaveAs(dialog.FileName);
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageService.ShowError(exception);
        }
    }

    private string GetMonthName(int month)
    {
        try
        {
            switch (month)
            {
                case 1:
                    return "Января";
                case 2:
                    return "Февраля";
                case 3:
                    return "Марта";
                case 4:
                    return "Апреля";
                case 5:
                    return "Мая";
                case 6:
                    return "Июня";
                case 7:
                    return "Июля";
                case 8:
                    return "Августа";
                case 9:
                    return "Сентября";
                case 10:
                    return "Октября";
                case 11:
                    return "Ноября";
                case 12:
                    return "Декабря";
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            MessageService.ShowError(e);
        }

        return "";
    }

    private void AddContractButton_OnClick(object sender, RoutedEventArgs e) =>
        NavigationService.Navigate(new AddContractPage(_client.PassportId));

    private void DocumentLoadButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            ClientFile file = (((Button)sender).DataContext as ClientFile)!;

            SaveFileDialog dialog = new SaveFileDialog()
                { DefaultExt = file.FileName.Split('.').Last(), FileName = file.FileName };
            if (dialog.ShowDialog() == true)
            {
                File.WriteAllBytes(dialog.FileName, file.FileData);
                Clipboard.SetText(dialog.FileName);
                MessageService.ShowOk("Файл сохранен! Путь к файлу скопирован в буфер обмена.");
            }
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
            ClientFile file = (ClientFile)((Button)sender).DataContext;
            Db.Context.ClientFiles.Remove(file);
            DatabaseSaveService.SaveWithMessage();
            LoadData();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageService.ShowError(exception);
        }
    }

    private async void DocumentAddButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            OpenFileDialog dialog = new() { Filter = "documents (.docx, .doc, .pdf)|*.docx; *.doc; *.pdf; " };
            if (dialog.ShowDialog() == true)
            {
                ClientFile file = new()
                {
                    ClientId = _client.PassportId, FileData = File.ReadAllBytes(dialog.FileName),
                    FileName = dialog.SafeFileName
                };
                Db.Context.ClientFiles.Add(file);
                DatabaseSaveService.SaveWithMessage("Документ загружен!");
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