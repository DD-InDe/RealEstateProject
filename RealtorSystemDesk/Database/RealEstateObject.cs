using System;
using System.Collections.Generic;

namespace RealtorSystemDesk.Database;

public partial class RealEstateObject
{
    public int ContractId { get; set; }

    public string? Address { get; set; }

    public string? Description { get; set; }

    public string? Notes { get; set; }

    public int? Floor { get; set; }

    public int? FloorsCount { get; set; }

    public int? RoomsCount { get; set; }

    public decimal? Square { get; set; }

    public decimal? Price { get; set; }

    public int? BuildingYear { get; set; }

    public int? ObjectTypeId { get; set; }

    public bool? IsArchive { get; set; }

    public virtual Contract Contract { get; set; } = null!;

    public virtual RealEstateObjectType? ObjectType { get; set; }

    public virtual ICollection<RealEstateObjectPhoto> RealEstateObjectPhotos { get; set; } = new List<RealEstateObjectPhoto>();
}
