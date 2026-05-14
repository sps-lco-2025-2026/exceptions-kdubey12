string[] names = { "Alice", "Bob", "Charlie" };
Console.Write("Enter an index: ");

try
{
    int i = int.Parse(Console.ReadLine()!);
    Console.WriteLine(names[i]);


}
catch (FormatException e)
{
    Console.WriteLine($"Inputted index is not an integer: {e.Message}");
}
catch (IndexOutOfRangeException e)
{
    Console.WriteLine($"Index is out of range of the list: {e.Message}");
}
