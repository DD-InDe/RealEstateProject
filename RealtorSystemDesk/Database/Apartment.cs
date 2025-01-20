using System;
using System.Collections.Generic;

namespace RealtorSystemDesk.Database;

public partial class Apartment
{
    public string? CadastralNumber { get; set; }

    public decimal? Square { get; set; }

    public int? Floor { get; set; }

    public virtual RealEstateObject? CadastralNumberNavigation { get; set; }
}
