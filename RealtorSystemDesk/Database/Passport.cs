using System;
using System.Collections.Generic;

namespace RealtorSystemDesk.Database;

public partial class Passport
{
    public int Id { get; set; }

    public int? Serial { get; set; }

    public int? Number { get; set; }

    public DateOnly? IssuedDate { get; set; }

    public string? IssuedBy { get; set; }

    public virtual Client? Client { get; set; }
}
