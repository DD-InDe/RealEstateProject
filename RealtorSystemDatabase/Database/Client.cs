using System;
using System.Collections.Generic;

namespace RealtorSystemDatabase.Database;

public partial class Client
{
    public int PassportId { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public DateOnly? BirthDate { get; set; }

    public char? GenderId { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public bool? IsArchive { get; set; }

    public virtual ICollection<ClientFile> ClientFiles { get; set; } = new List<ClientFile>();

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual Gender? Gender { get; set; }

    public virtual Passport Passport { get; set; } = null!;
}
