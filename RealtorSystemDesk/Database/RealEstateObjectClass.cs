using System;
using System.Collections.Generic;

namespace RealtorSystemDesk.Database;

public partial class RealEstateObjectClass
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<RealEstateObject> RealEstateObjects { get; set; } = new List<RealEstateObject>();
}
