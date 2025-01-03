using System.Configuration;
using System.Data;
using System.Windows;
using RealtorSystemDesk.Database;

namespace RealtorSystemDesk;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static User? AuthorizedUser { get; set; }
}