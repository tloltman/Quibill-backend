namespace Quibill.Domain
{
    internal interface ITransaction
    {
        int TransactionId { get; }
        decimal TransactionAmount { get;}
        DTO.Enums.TransactionType TransactionType { get; }
        System.DateTime AddDate { get; }

    }
}