using System.Windows.Controls;
using RealtorSystemDesk.Database;

namespace RealtorSystemDesk.Pages.ObjectManagePages;

public partial class ObjectEditPage : Page
{
    private RealEstateObject _estateObject;

    public ObjectEditPage(RealEstateObject estateObject)
    {
        _estateObject = estateObject;
        InitializeComponent();
    }

    public ObjectEditPage()
    {
        _estateObject = new();
        InitializeComponent();
    }
}