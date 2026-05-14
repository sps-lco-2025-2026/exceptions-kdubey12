Console.Write("Enter a number: ");

try {
    int n = int.Parse(Console.ReadLine()!);
    Console.WriteLine(100 / n);
}
catch (FormatException e)
{
    Console.WriteLine($"Input was not an integer: {e.Message}");
}
catch (DivideByZeroException)
{
    Console.WriteLine("Cannot divide by zero.");
}
finally
{
    Console.WriteLine("Calculation complete.");
}

