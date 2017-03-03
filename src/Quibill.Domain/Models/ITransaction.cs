namespace Quibill.Domain
{
    internal interface ITransaction
    {
        int TransactionId { get; }
        float TransactionAmount { get;}
        string TransactionType { get; } // TODO make this an enum?
        System.DateTime TransactionDate { get; }

    }
}