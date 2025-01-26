namespace RealtorSystemDatabase.Database;

public partial class RealEstateObjectPhoto
{
    public byte[] ХУЙ => Convert.FromBase64String(Photo);
}