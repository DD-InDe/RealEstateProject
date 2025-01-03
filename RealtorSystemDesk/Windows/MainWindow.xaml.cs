using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RealtorSystemDesk.Pages;
using RealtorSystemDesk.Services;

namespace RealtorSystemDesk;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private object Page;
    
    class Menu()
    {
        public bool Object { get; set; } = true;
        public bool Client { get; set; }
        public bool Account { get; set; }
    }

    private Menu _menu;

    public MainWindow()
    {
        _menu = new();
        InitializeComponent();

        DataContext = _menu;
    }

    private void ToggleButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            ToggleButton button = (sender as ToggleButton)!;
            List<ToggleButton> buttons = MenuGrid.Children.OfType<ToggleButton>().ToList();

            buttons.Remove(button);
            foreach (var toggleButton in buttons)
                toggleButton.IsChecked = false;

            if (_menu.Object) MainFrame.Navigate(new ViewAllObjectPage());
            else if (_menu.Client) MainFrame.Navigate(new ViewAllClientPage());
            else MainFrame.Navigate(new AccountManagePage());
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            MessageService.ShowError(exception);
        }
    }
}