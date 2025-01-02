using System;
using System.Collections.Generic;

namespace RealtorSystemDesk.Database;

public partial class ContractDocument
{
    public int Id { get; set; }

    public int? ContractId { get; set; }

    public int? DocumentId { get; set; }

    public virtual Contract? Contract { get; set; }

    public virtual Document? Document { get; set; }
}
