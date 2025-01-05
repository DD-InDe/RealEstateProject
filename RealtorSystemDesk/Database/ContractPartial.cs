using System.Windows;

namespace RealtorSystemDesk.Database;

public partial class Contract
{
    public string Active => IsArchive!.Value ? "Архив" : "Активен";
    public Visibility ArchiveButtonVisibility => IsArchive!.Value ? Visibility.Collapsed : Visibility.Visible;
}