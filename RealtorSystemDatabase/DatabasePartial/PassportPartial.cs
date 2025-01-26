using System.ComponentModel.DataAnnotations.Schema;

namespace RealtorSystemDatabase.Database;

public partial class Passport
{
    [NotMapped]
    public DateTime? IssuedDateTime
    {
        get
        {
            var issuedDate = this.IssuedDate;
            if (issuedDate != null) return issuedDate.Value.ToDateTime(new());
            else return null;
        }
        set { this.IssuedDate = DateOnly.FromDateTime(value.Value); }
    }
}