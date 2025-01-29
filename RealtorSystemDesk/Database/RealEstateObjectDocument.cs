using System;
using System.Collections.Generic;

namespace RealtorSystemDesk.Database;

public partial class RealEstateObjectDocument
{
    public int Id { get; set; }

    public string? ObjectNumber { get; set; }

    public int? DocumentTypeId { get; set; }

    public byte[]? Document { get; set; }

    public virtual DocumentType? DocumentType { get; set; }

    public virtual RealEstateObject? ObjectNumberNavigation { get; set; }
}
