using System;
using System.Collections.Generic;

namespace RealtorSystemDesk.Database;

public partial class RealEstateObjectPhoto
{
    public int Id { get; set; }

    public int? RealEstateObjectId { get; set; }

    public string? Photo { get; set; }

    public virtual RealEstateObject? RealEstateObject { get; set; }
}
