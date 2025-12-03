namespace Banking.Domain
{
    public interface IFraudService
    {
        // Ini adalah kontrak: "Siapapun yang jadi FraudService harus punya method ini"
        bool IsTransferAllowed(int accountId, decimal amount);
    }
}