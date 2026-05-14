class TemperatureException : Exception
{
    public double AttemptedValue { get; }

    public TemperatureException(double temp)
    {
        AttemptedValue = temp;
    }

    public TemperatureException(double temp, string message)
        : base(message)
    {
        AttemptedValue = temp;
    }
    
    public TemperatureException(double temp, string message, Exception inner)
        : base(message, inner)
    {
        AttemptedValue = temp;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter a temperature in Celsius: ");

        try
        {
            double temp = double.Parse(Console.ReadLine()!);
            if (temp < -273.15) throw new TemperatureException(temp);
            Console.WriteLine($"{temp} C = {(temp * 1.8) + 32:0.##} F");
        }
        catch (FormatException e)
        {
            Console.WriteLine("Input was not a double. " + e.Message);
        }
        catch (TemperatureException e)
        {
            Console.WriteLine($"{e.AttemptedValue} is below absolute zero (minimum: -273.15)");
        }
    }
}

