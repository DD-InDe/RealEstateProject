using System;
using System.Collections.Generic;

namespace RealtorSystemDatabase.Database;

public partial class RealEstateObjectType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<RealEstateObject> RealEstateObjects { get; set; } = new List<RealEstateObject>();
}
