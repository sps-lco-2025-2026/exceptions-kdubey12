// exercise 3
Console.Write("Enter a number: ");

try
{
    int n = int.Parse(Console.ReadLine()!);
    bool isEven = n % 2 == 0;
}
catch (FormatException e)
{
    Console.WriteLine($"Input was not a number: {e.Message}");
}
finally
{
    Console.WriteLine("Thank you for using the program.");
}