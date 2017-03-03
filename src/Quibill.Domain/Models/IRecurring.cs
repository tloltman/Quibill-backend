namespace Quibill.Domain
{
    internal interface IRecurring
    {
        System.DateTime RecurrenceStartDate { get; }
        System.DateTime ReccurenceRate { get; }
    }
}