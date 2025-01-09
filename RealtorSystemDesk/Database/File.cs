using System;
using System.Collections.Generic;

namespace RealtorSystemDesk.Database;

public partial class File
{
    public int Id { get; set; }

    public string? FileName { get; set; }

    public virtual ICollection<ClientFile> ClientFiles { get; set; } = new List<ClientFile>();
}
