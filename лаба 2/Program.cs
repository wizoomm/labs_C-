using labrab2;

internal class Program
{
    List<Composition> compositions = new List<Composition>();
    private void PrintHelp()
    {
        Console.WriteLine(@"
Usage:
    List of available commands:
        list - display all items in the catalog
        search - find items by query
        add - add new item
        del - delete item by full name
        quit - exit
");
    }

    private string PromptUser(string prompt)
    {
        Console.WriteLine(prompt);
        Console.Write("> ");
        return Console.ReadLine()!;
    }

    private void RunList()
    {
        foreach (Composition composition in compositions)
        {
            Console.WriteLine(composition.ToString());
        }
    }

    private void RunSearch()
    {
        string query = PromptUser("Enter Query");
        Console.WriteLine("Search results:");
        bool found = false;
        foreach(Composition composition in compositions) 
        { 
            if(composition.SearchMatches(query))
            {
                Console.WriteLine(composition.ToString());
                found = true;
            }
        }
        if(!found)
        {
            Console.WriteLine("No results found");
        }
    }

    private void RunAdd()
    {
        string composer = PromptUser("Enter composer name:");
        string name = PromptUser("Enter composition name:");
        compositions.Add(new Composition(name, composer));
    }

    private void RunDel()
    {
        string fullName = PromptUser("Enter full composition name:");
        int index = compositions.FindIndex((Composition composition) => composition.ToString() == fullName);
        if (index == -1)
        {
            Console.WriteLine("No composition was found.");
        } 
        else
        {
            Console.WriteLine("Removing composition " + compositions[index].ToString());
            compositions.RemoveAt(index);
        }
    }

    private void Run()
    {
        PrintHelp();
        while(true)
        {
            string action = PromptUser("Enter command");
            if(action == "quit")
            {
                break;
            } 
            else if (action == "list")
            {
                RunList();
            } 
            else if (action == "search")
            {
                RunSearch();
            }
            else if (action == "add")
            {
                RunAdd();
            }
            else if (action == "del")
            {
                RunDel();
            }
            else
            {
                PrintHelp();
            }
            Console.WriteLine("---");
        }
    }
    private static void Main(string[] args)
    {
        (new Program()).Run();
    }
}