// Snippet A
try
{
    int[] arr = new int[3];
    arr[10] = 5;
}
catch (IndexOutOfRangeException e)
{
    Console.WriteLine("Assigning out of range! " + e.Message);
}

// Snippet B
try
{
    string s = null!;
    Console.WriteLine(s.Length);
}
catch (NullReferenceException e)
{
    Console.WriteLine("Attempted to invoke method on null reference. " + e.Message);
}

// Snippet C

    int x = int.MaxValue;
    checked { x = x + 1; }

