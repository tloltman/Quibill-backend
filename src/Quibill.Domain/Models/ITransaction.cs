namespace Quibill.Domain
{
    public interface ITransaction
    {
        int TransactionId { get; set; }
        decimal TransactionAmount { get; set; }
        DTO.Enums.TransactionType TransactionType { get; set; }
        System.DateTime AddDate { get; set; }
        string BoundUserId { get; set; }

    }
}