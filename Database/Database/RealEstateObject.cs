using System;
using System.Collections.Generic;

namespace Database.Database;

public partial class RealEstateObject
{
    public string CadastralNumber { get; set; } = null!;

    public string? Address { get; set; }

    public int? YearOfBuilding { get; set; }

    public int? RoomsCount { get; set; }

    public int? TypeId { get; set; }

    public int? ContractId { get; set; }

    public int ClassId { get; set; }

    public decimal? Price { get; set; }

    public decimal? Square { get; set; }

    public decimal? PlotSquare { get; set; }

    public int? FloorsCount { get; set; }

    public string? Material { get; set; }

    public virtual RealEstateObjectClass Class { get; set; } = null!;

    public virtual Contract? Contract { get; set; }

    public virtual RealEstateObjectType? Type { get; set; }
}
