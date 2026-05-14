class InventoryException : Exception
{
    public string AttemptedInventoryCommand { get; }

    public InventoryException(string inventoryCommand)
        : base("InventoryException: Invalid inventory command.")
    {
        AttemptedInventoryCommand = inventoryCommand;
    }

    public InventoryException(string inventoryCommand, Exception inner)
        : base("InventoryException: Invalid inventory command.", inner)
    {
        AttemptedInventoryCommand = inventoryCommand;
    }
}

class ItemNotFoundException : InventoryException
{
    public ItemNotFoundException(string inventoryCommand)
        : base(inventoryCommand, $"{inventoryCommand.Split(' ')[1]} was not found in inventory. ") { }
}

class InsufficientQuantityException : InventoryException
{
    public InsufficientQuantityException(string inventoryCommand)
        : base(inventoryCommand, $"{inventoryCommand.Split(' ')[1]} was not available in sufficient quantity.");
}

class Program
{
    static void Main()
    {
        Dictionary<string, int> inventory = new Dictionary<string, int>
        {
            {"sword", 1},
            {"potion", 3}, 
            {"map", 1},
            {"shield", 2}
        };

        string? inp = "";
        while (inp.toLowerInvariant() != "q")
        {
            try
            {
                Console.WriteLine("Enter a command:");
                inp = Console.Readline().toLowerInvariant();
                
                vals = inp.Split(' ');
                if (vals[0] == "take")
                {
                    if (inventory.ContainsKey(vals[1]))
                    {
                        if (inventory[vals[1]] > 0)
                            inventory[vals[1]]--;
                        else
                            throw new InsufficientQuantityException(inp);
                    }

                    else
                    {
                        throw new ItemNotFoundException(inp);
                    }
                }
                if (vals[0] == "place")
                {
                    if (inventory.ContainsKey(vals[1])) inventory[vals[1]]++;
                    else inventory.Add(vals[1], 1);
                }
            }
            catch (InsufficientQuantityException e)
            {
                Console.WriteLine($"{e.AttemptedInventoryCommand.Split(' ')[1]} is not available in sufficient quantity.");
                Console.WriteLine(e.Message);
            }
            catch (ItemNotFoundException e)
            {
                Console.WriteLine($"{e.AttemptedInventoryCommand.Split(' ')[1]} is not present in your inventory.");
                Console.WriteLine(e.Message);
            }
        }
    }
}