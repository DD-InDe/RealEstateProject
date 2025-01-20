using System;
using System.Collections.Generic;

namespace Database.Database;

public partial class Gender
{
    public char Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
