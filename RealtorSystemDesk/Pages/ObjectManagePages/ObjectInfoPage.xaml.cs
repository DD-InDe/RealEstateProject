using System.Buffers.Text;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using RealtorSystemDesk.Database;
using RealtorSystemDesk.Enums;
using RealtorSystemDesk.Pages.ClientManagePages;
using RealtorSystemDesk.Services;
using File = System.IO.File;
using Image = System.Windows.Controls.Image;

namespace RealtorSystemDesk.Pages.ObjectManagePages;

public partial class ObjectInfoPage : Page
{
    private List<RealEstateObjectPhoto> _files;
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
                    .Include(c => c.ObjectType)
                    .FirstAsync(c => c.ContractId == _id);

                ArchiveButton.Content = _object.IsArchive.Value ? "Убрать из архива" : "Добавить в архив";
                MainGrid.DataContext = _object;
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
            _files = Db
                .Context.RealEstateObjectPhotos.Where(c => c.RealEstateObjectId == _object.ContractId)
                .ToList();
            PhotoItemsControl.ItemsSource = null;
            PhotoItemsControl.ItemsSource = _files;
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
                    RealEstateObjectId = _object.ContractId,
                    Photo = Convert.ToBase64String(File.ReadAllBytes(dialog.FileName))
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

    private void ArchiveButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            _object.IsArchive = !_object.IsArchive.Value;
            DatabaseSaveService.SaveWithMessage();

            ArchiveButton.Content = _object.IsArchive.Value ? "Убрать из архива" : "Добавить в архив";
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageService.ShowError(exception);
        }
    }
}