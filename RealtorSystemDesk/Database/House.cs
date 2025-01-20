using System;
using System.Collections.Generic;

namespace RealtorSystemDesk.Database;

public partial class House
{
    public string? CadastralNumber { get; set; }

    public decimal? Square { get; set; }

    public decimal? PlotSquare { get; set; }

    public int? FloorsCount { get; set; }

    public string? Material { get; set; }

    public virtual RealEstateObject? CadastralNumberNavigation { get; set; }
}
