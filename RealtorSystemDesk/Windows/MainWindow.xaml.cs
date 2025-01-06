using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Navigation;
using RealtorSystemDesk.Pages;
using RealtorSystemDesk.Services;

namespace RealtorSystemDesk;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        ProfileFrame.Navigate(new AccountManagePage(false));
    }

    private void ClientBackButton_OnClick(object sender, RoutedEventArgs e) => ClientFrame.GoBack();

    private void ClientFrame_OnNavigated(object sender, NavigationEventArgs e) => ClientBackButton.Visibility =
        ClientFrame.CanGoBack ? Visibility.Visible : Visibility.Hidden;

    private void ObjectBackButton_OnClick(object sender, RoutedEventArgs e) => ObjectFrame.GoBack();

    private void ObjectFrame_OnNavigated(object sender, NavigationEventArgs e) => ObjectBackButton.Visibility =
        ObjectFrame.CanGoBack ? Visibility.Visible : Visibility.Hidden;
}