namespace Handy.Models;

public record struct PercentValue
{
    public double Value { get; init; }

    public PercentValue(double value)
    {
        if (value < 0 || value > 100)
            throw new ArgumentOutOfRangeException(nameof(value), "percent must be between 0 and 100.");

        Value = value;
    }

    public override string ToString() => Value.ToString();
}
