namespace CourseProject.Core.Entities;

public class IndicatorValue
{
    public int Id { get; set; }
    public string Value { get; set; }
    public DateTime DateTime { get; set; }
    public Indicator Indicator { get; set; }
}