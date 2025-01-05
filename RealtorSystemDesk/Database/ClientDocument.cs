using System;
using System.Collections.Generic;

namespace RealtorSystemDesk.Database;

public partial class ClientDocument
{
    public int Id { get; set; }

    public int? ClientId { get; set; }

    public int? DocumentId { get; set; }

    public virtual Client? Client { get; set; }

    public virtual Document? Document { get; set; }
}
