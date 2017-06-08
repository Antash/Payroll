namespace Payroll.Interfaces
{
    public interface IEmployee
    {
        ILocation Location { get; }
        uint HoursWorked { get; }
        decimal HourlyRate { get; }
    }
}
