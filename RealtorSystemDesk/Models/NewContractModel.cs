using RealtorSystemDesk.Database;

namespace RealtorSystemDesk.Models;

public class NewContractModel
{
    public int ClientId { get; set; }
    public ContractType Type { get; set; }

    private int _days;

    public int Days
    {
        get => _days;
        set => _days = value > 0 ? value : 1;
    }

    public DateTime DateCreate { get; set; }
}