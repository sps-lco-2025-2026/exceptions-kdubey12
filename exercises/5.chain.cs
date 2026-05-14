using System;

int Divide(int a, int b)
{
    try
    {
        return a/b;
    }
    catch (DivideByZeroException ex)
    {
        throw new ArgumentException("Denominator cannot be zero.", ex);
    }
    finally
    {
        Console.WriteLine("Division Attempted");
    }
}

int ReadAndDivide()
{
    Console.Write("Numerator: ");
    int a = int.Parse(Console.ReadLine()!);
    Console.Write("Denominator: ");
    int b = int.Parse(Console.ReadLine()!);

    try
    {
        return Divide(a, b);
    }
    catch (ArgumentException e)
    {
        Console.WriteLine("Argument Error - Cannot divide by zero.\n" + e.InnerException?.Message);
        return 0;
    }
    
}

Console.WriteLine(ReadAndDivide());