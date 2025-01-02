using System;
using System.Collections.Generic;

namespace RealtorSystemDesk.Database;

public partial class RealEstateObjectPhoto
{
    public int Id { get; set; }

    public int? ObjectId { get; set; }

    public string? FileName { get; set; }

    public virtual RealEstateObject? Object { get; set; }
}
