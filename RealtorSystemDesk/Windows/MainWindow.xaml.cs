using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Navigation;
using MaterialDesignThemes.Wpf;
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
        this.MinWidth = 1300;
        this.MinHeight = 600;
        InitializeComponent();
        DataContext = this;
    }

    private void Theme_Change(object sender, RoutedEventArgs e)
    {
        PaletteHelper helper = new PaletteHelper();
        var theme = helper.GetTheme();
        if (DarkModeSwitch.IsChecked.HasValue && DarkModeSwitch.IsChecked.Value)
        {
            theme.SetBaseTheme(BaseTheme.Dark);
            LightLogImage.Visibility = Visibility.Collapsed;
            DarkLogImage.Visibility = Visibility.Visible;
        }
        else
        {
            theme.SetBaseTheme(BaseTheme.Light);
            LightLogImage.Visibility = Visibility.Visible;
            DarkLogImage.Visibility = Visibility.Collapsed;
        }

        helper.SetTheme(theme);
    }

    private void MainFrame_OnNavigated(object sender, NavigationEventArgs e)
    {
        // включение меню для пустой страницы
        if (MainFrame.Content == null)
        {
            MenuPanel.Visibility = Visibility.Visible;
            return;
        }

        // отключения меню для авторизации
        MenuPanel.Visibility = MainFrame.Content.GetType() == typeof(AuthPage) || App.AuthorizedUser == null
            ? Visibility.Collapsed
            : Visibility.Visible;

        if (MainFrame.Content.GetType() == typeof(ViewAllObjectPage) ||
            MainFrame.Content.GetType() == typeof(ViewAllClientPage) ||
            MainFrame.Content.GetType() == typeof(AuthPage) ||
            (MainFrame.Content.GetType() == typeof(AccountManagePage) && App.AuthorizedUser != null))
            ClearHistory();

        BackButton.Visibility = MainFrame.CanGoBack ? Visibility.Visible : Visibility.Collapsed;
    }

    private void BackButton_OnClick(object sender, RoutedEventArgs e) => MainFrame.GoBack();

    private void AccountButton_OnClick(object sender, RoutedEventArgs e) =>
        MainFrame.NavigationService.Navigate(new AccountManagePage(false));

    private void ObjectButton_OnClick(object sender, RoutedEventArgs e) =>
        MainFrame.NavigationService.Navigate(new ViewAllObjectPage());

    private void ClientButton_OnClick(object sender, RoutedEventArgs e) =>
        MainFrame.NavigationService.Navigate(new ViewAllClientPage());


    private void ClearHistory()
    {
        if (MainFrame.CanGoBack)
        {
            var journalEntry = MainFrame.RemoveBackEntry();
            while (journalEntry != null)
            {
                journalEntry = MainFrame.RemoveBackEntry();
            }

            BackButton.Visibility = Visibility.Collapsed;
        }
    }
}