namespace RealtorSystemDesk.Database;

public partial class RealEstateObject
{
    public string Status => IsArchive.Value ? "Архив" : "Активный";
}