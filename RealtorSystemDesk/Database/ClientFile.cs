using System;
using System.Collections.Generic;

namespace RealtorSystemDesk.Database;

public partial class ClientFile
{
    public int Id { get; set; }

    public int? ClientId { get; set; }

    public string? FileName { get; set; }

    public byte[]? FileData { get; set; }

    public virtual Client? Client { get; set; }
}
