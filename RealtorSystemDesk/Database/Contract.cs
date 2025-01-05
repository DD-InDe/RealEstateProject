using System;
using System.Collections.Generic;

namespace RealtorSystemDesk.Database;

public partial class Contract
{
    public int Id { get; set; }

    public DateOnly? DateCreate { get; set; }

    public DateOnly? ValidUntil { get; set; }

    public int? ClientId { get; set; }

    public int? TypeId { get; set; }

    public bool? IsArchive { get; set; }

    public virtual Client? Client { get; set; }

    public virtual ICollection<ContractDocument> ContractDocuments { get; set; } = new List<ContractDocument>();

    public virtual RealEstateObject? RealEstateObject { get; set; }

    public virtual ContractType? Type { get; set; }
}
