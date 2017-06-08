namespace Payroll.Interfaces
{
    public interface IEmployee
    {
        string Location { get; }
        uint HoursWorked { get; }
        decimal HourlyRate { get; }
    }
}
