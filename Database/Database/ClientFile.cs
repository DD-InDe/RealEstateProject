using System;
using System.Collections.Generic;

namespace Database.Database;

public partial class ClientFile
{
    public int Id { get; set; }

    public int? ClientId { get; set; }

    public int? FileId { get; set; }

    public virtual Client? Client { get; set; }

    public virtual File? File { get; set; }
}
