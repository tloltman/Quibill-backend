namespace Quibill.Domain
{
    internal interface IRecurring
    {
        System.DateTime RecurrenceStartDate { set; }
        System.DateTime ReccurenceRate { set; }
    }
}