using System;
using System.Collections.Generic;

namespace RealtorSystemDatabase.Database;

public partial class ContractType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}
