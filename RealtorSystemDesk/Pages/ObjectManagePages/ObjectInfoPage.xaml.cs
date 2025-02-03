using System.Buffers.Text;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using RealtorSystemDesk.Database;
using RealtorSystemDesk.Pages.ClientManagePages;
using RealtorSystemDesk.Services;
using File = System.IO.File;
using Image = System.Windows.Controls.Image;

namespace RealtorSystemDesk.Pages.ObjectManagePages;

public partial class ObjectInfoPage : Page
{
    private List<RealEstateObjectPhoto> _photos;
    private List<RealEstateObjectDocument> _documents;
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
                _object = await Db
                    .Context.RealEstateObjects
                    .Include(c => c.Contract)
                    .Include(c => c.Type)
                    .Include(c => c.Class)
                    .FirstAsync(c => c.ContractId == _id);

                MainPanel.DataContext = _object;
                if (_object.TypeId == 1)
                {
                    ApartmentPanel.Visibility = Visibility.Collapsed;
                    HousePanel.Visibility = Visibility.Visible;
                }
                else
                {
                    ApartmentPanel.Visibility = Visibility.Visible;
                    HousePanel.Visibility = Visibility.Collapsed;
                }

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

    private void LoadData()
    {
        try
        {
            _photos = Db
                .Context.RealEstateObjectPhotos.Where(c => c.ObjectNumber == _object.CadastralNumber)
                .ToList();
            PhotoItemsControl.ItemsSource = null;
            PhotoItemsControl.ItemsSource = _photos;

            _documents = Db.Context.RealEstateObjectDocuments.Include(c => c.DocumentType)
                .Where(c => c.ObjectNumber == _object.CadastralNumber).ToList();
            DocumentListView.ItemsSource = null;
            DocumentListView.ItemsSource = _documents;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            MessageService.ShowError(e);
        }
    }

    private void CustomerButton_OnClick(object sender, RoutedEventArgs e) =>
        NavigationService.Navigate(new ClientInfoPage(_object.Contract.ClientId.Value));

    private void AddPhotoButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            OpenFileDialog dialog = new()
            {
                Filter = "images |*.jpeg; *.jpg; *.png"
            };
            if (dialog.ShowDialog() == true)
            {
                RealEstateObjectPhoto photo = new()
                {
                    ObjectNumber = _object.CadastralNumber,
                    Photo = File.ReadAllBytes(dialog.FileName)
                };
                Db.Context.RealEstateObjectPhotos.Add(photo);

                DatabaseSaveService.SaveWithMessage();
                LoadData();
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageService.ShowError(exception);
        }
    }

    private void DeleteItem_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            RealEstateObjectPhoto photo = ((MenuItem)sender).DataContext as RealEstateObjectPhoto;
            Db.Context.RealEstateObjectPhotos.Remove(photo);
            DatabaseSaveService.SaveWithMessage();
            LoadData();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageService.ShowError(exception);
        }
    }

    private void FileButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            RealEstateObjectDocument document = ((Button)sender).DataContext as RealEstateObjectDocument;
            if (document.Document != null)
            {
                string defaultName = $"{_object.CadastralNumber}_{document.DocumentType.Name}.pdf";
                SaveFileDialog dialog = new SaveFileDialog()
                    { DefaultExt = ".pdf", Filter = "pdf | *.pdf", FileName = defaultName };
                if (dialog.ShowDialog() == true)
                {
                    File.WriteAllBytes(dialog.FileName, document.Document);
                    Clipboard.SetText(dialog.FileName);
                    MessageService.ShowOk("Файл сохранен! Путь к файлу скопирован в буффер обмена");
                }
            }
            else
            {
                OpenFileDialog dialog = new OpenFileDialog() { Filter = "pdf | *.pdf" };
                if (dialog.ShowDialog() == true)
                {
                    document.Document = File.ReadAllBytes(dialog.FileName);
                    DatabaseSaveService.SaveWithMessage("Файл загружен!");
                }
            }
            
            LoadData();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageService.ShowError(exception);
        }
    }
}