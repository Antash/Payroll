namespace Payroll.Interfaces
{
    public interface IEmployee
    {
        string LocationName { get; }
        uint HoursWorked { get; }
        decimal HourlyRate { get; }
    }
}
