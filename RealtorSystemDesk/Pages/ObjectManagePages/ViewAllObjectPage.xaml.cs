using System.Windows;
using System.Windows.Controls;
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
            
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageService.ShowError(exception);
        }
    }

    private void SearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void CheckBox_Check(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void AddButton_OnClick(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }
}