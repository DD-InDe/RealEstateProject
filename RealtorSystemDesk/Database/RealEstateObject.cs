using System;
using System.Collections;
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

    public BitArray? IsArchive { get; set; }

    public int? ObjectType { get; set; }

    public virtual Contract Contract { get; set; } = null!;

    public virtual RealEstateObjectType? ObjectTypeNavigation { get; set; }

    public virtual ICollection<RealEstateObjectDocument> RealEstateObjectDocuments { get; set; } = new List<RealEstateObjectDocument>();

    public virtual ICollection<RealEstateObjectPhoto> RealEstateObjectPhotos { get; set; } = new List<RealEstateObjectPhoto>();
}
