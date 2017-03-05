namespace Quibill.Domain
{
    internal interface ITransaction
    {
        int TransactionId { get; }
        decimal TransactionAmount { get;}
        string TransactionType { get; } // TODO make this an enum?
        System.DateTime AddDate { get; }

    }
}