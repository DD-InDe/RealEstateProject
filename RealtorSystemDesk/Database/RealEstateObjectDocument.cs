using System;
using System.Collections.Generic;

namespace RealtorSystemDesk.Database;

public partial class RealEstateObjectDocument
{
    public string? ObjectNumber { get; set; }

    public byte[]? ExtractFromEgrn { get; set; }

    public byte[]? BasisOfOwnership { get; set; }

    public byte[]? SpousesConsent { get; set; }

    public byte[]? GuardianshipConsent { get; set; }

    public byte[]? CertificateOfNoDebt { get; set; }

    public byte[]? OwnersPassports { get; set; }

    public virtual RealEstateObject? ObjectNumberNavigation { get; set; }
}
