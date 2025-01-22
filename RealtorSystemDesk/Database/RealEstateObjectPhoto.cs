using System;
using System.Collections.Generic;

namespace RealtorSystemDesk.Database;

public partial class RealEstateObjectPhoto
{
    public int Id { get; set; }

    public string? ObjectNumber { get; set; }

    public byte[]? Photo { get; set; }

    public virtual RealEstateObject? ObjectNumberNavigation { get; set; }
}
