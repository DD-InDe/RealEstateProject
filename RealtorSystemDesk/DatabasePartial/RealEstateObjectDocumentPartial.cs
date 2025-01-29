namespace RealtorSystemDesk.Database;

public partial class RealEstateObjectDocument
{
    public string ButtonText => Document == null ? "Загрузить" : "Скачать";
}