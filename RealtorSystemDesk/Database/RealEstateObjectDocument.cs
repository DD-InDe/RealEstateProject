using System;
using System.Collections.Generic;

namespace RealtorSystemDesk.Database;

public partial class RealEstateObjectDocument
{
    public string? CadastralNumber { get; set; }

    public int? ExtractFromEgrn { get; set; }

    public int? BasisOfOwnership { get; set; }

    public int? SpousesConsent { get; set; }

    public int? GuardianshipConsent { get; set; }

    public int? CertificateOfNoDebt { get; set; }

    public int? OwnersPassports { get; set; }

    public virtual File? BasisOfOwnershipNavigation { get; set; }

    public virtual File? CertificateOfNoDebtNavigation { get; set; }

    public virtual File? ExtractFromEgrnNavigation { get; set; }

    public virtual File? GuardianshipConsentNavigation { get; set; }

    public virtual File? OwnersPassportsNavigation { get; set; }

    public virtual File? SpousesConsentNavigation { get; set; }
}
