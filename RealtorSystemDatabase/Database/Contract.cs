using System;
using System.Collections.Generic;

namespace RealtorSystemDatabase.Database;

public partial class Contract
{
    public int Id { get; set; }

    public DateOnly? DateCreate { get; set; }

    public DateOnly? ValidUntil { get; set; }

    public int? ClientId { get; set; }

    public int? TypeId { get; set; }

    public bool? IsArchive { get; set; }

    public int? UserId { get; set; }

    public virtual Client? Client { get; set; }

    public virtual RealEstateObject? RealEstateObject { get; set; }

    public virtual ContractType? Type { get; set; }

    public virtual User? User { get; set; }
}
