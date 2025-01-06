using System.ComponentModel.DataAnnotations.Schema;

namespace RealtorSystemDesk.Database;

public partial class Client
{
    public string FullName => $"{LastName} {FirstName} {MiddleName}";

    [NotMapped]
    public DateTime? BirthDateTime
    {
        get
        {
            var birthDate = this.BirthDate;
            if (birthDate != null) return birthDate.Value.ToDateTime(new());
            else return null;
        }
        set { this.BirthDate = DateOnly.FromDateTime(value.Value); }
    }
}