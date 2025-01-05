using System;
using System.Collections.Generic;

namespace RealtorSystemDesk.Database;

public partial class Passport
{
    public int Id { get; set; }

    public int? PassportSerial { get; set; }

    public int? PassportNumber { get; set; }

    public DateOnly? PassportIssuedDate { get; set; }

    public string? PassportIssuedBy { get; set; }

    public DateOnly? PassportValidUntil { get; set; }

    public virtual Client? Client { get; set; }
}
