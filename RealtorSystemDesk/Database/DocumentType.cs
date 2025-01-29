using System;
using System.Collections.Generic;

namespace RealtorSystemDesk.Database;

public partial class DocumentType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<RealEstateObjectDocument> RealEstateObjectDocuments { get; set; } = new List<RealEstateObjectDocument>();
}
