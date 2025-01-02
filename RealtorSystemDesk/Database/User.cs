using System;
using System.Collections.Generic;

namespace RealtorSystemDesk.Database;

public partial class User
{
    public int Id { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}
