using System;
using System.Collections.Generic;

namespace RealtorSystemDesk.Database;

public partial class Client
{
    public int PassportId { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public DateOnly? BirthDate { get; set; }

    public char? GenderId { get; set; }

    public int? UserId { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<ClientDocument> ClientDocuments { get; set; } = new List<ClientDocument>();

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual Gender? Gender { get; set; }

    public virtual Passport Passport { get; set; } = null!;

    public virtual User? User { get; set; }
}
