using System.Windows;

namespace RealtorSystemDesk.Database;

public partial class Contract
{
    public Visibility ObjectButtonVisibility => TypeId == 1 ? Visibility.Collapsed : Visibility.Visible;
}