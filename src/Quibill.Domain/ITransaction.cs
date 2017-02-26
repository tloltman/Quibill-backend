namespace Quibill.Domain
{
    internal interface ITransaction
    {
        int TransactionId { set; }
        float TransactionAmount { set;}
        string TransactionType { set; } // TODO make this an enum?
        System.DateTime TransactionDate { set; }

    }
}