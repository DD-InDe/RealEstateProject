namespace RealtorSystemDesk.Database;

public partial class Client
{
    public string FullName => $"{LastName} {FirstName} {MiddleName}";
    public DateTime BirthDateTime;
}