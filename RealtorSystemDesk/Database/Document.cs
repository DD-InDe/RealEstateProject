using System;
using System.Collections.Generic;

namespace RealtorSystemDesk.Database;

public partial class Document
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public string? FileName { get; set; }

    public virtual ICollection<ClientDocument> ClientDocuments { get; set; } = new List<ClientDocument>();

    public virtual ICollection<ContractDocument> ContractDocuments { get; set; } = new List<ContractDocument>();

    public virtual ICollection<RealEstateObjectDocument> RealEstateObjectDocuments { get; set; } = new List<RealEstateObjectDocument>();
}
