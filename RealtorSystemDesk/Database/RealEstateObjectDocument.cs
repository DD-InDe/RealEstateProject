using System;
using System.Collections.Generic;

namespace RealtorSystemDesk.Database;

public partial class RealEstateObjectDocument
{
    public int Id { get; set; }

    public int? RealEstateObjectId { get; set; }

    public int? DocumentId { get; set; }

    public virtual Document? Document { get; set; }

    public virtual RealEstateObject? RealEstateObject { get; set; }
}
