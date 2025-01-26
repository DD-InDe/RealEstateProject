using System;
using System.Collections.Generic;

namespace RealtorSystemDatabase.Database;

public partial class RealEstateObjectClass
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<RealEstateObject> RealEstateObjects { get; set; } = new List<RealEstateObject>();
}
