using labrab3;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

internal class CompositionsProgram: AbstractProgram
{ 
    Compositions compositions = new Compositions() { Values = new List<Composition>() };
    private void PrintHelp()
    {
        Console.WriteLine(@"
Usage:
    List of available commands:
        list - display all items in the catalog
        search - find items by query
        add - add new item
        del - delete item by full name
        save - save items to disk
        load - load items from disk
        quit - exit
");
    }

    private void RunList()
    {
        foreach (Composition composition in compositions.Values)
        {
            Console.WriteLine(composition.ToString());
        }
    }

    private void RunSearch()
    {
        string query = PromptUser("Enter Query");
        Console.WriteLine("Search results:");
        bool found = false;
        foreach(Composition composition in compositions.Values) 
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
        compositions.Values.Add(new Composition()
        {
            Name = name,
            Composer = composer
        });
    }

    private void RunDel()
    {
        string fullName = PromptUser("Enter full composition name:");
        int index = compositions.Values.FindIndex((Composition composition) => composition.ToString() == fullName);
        if (index == -1)
        {
            Console.WriteLine("No composition was found.");
        } 
        else
        {
            Console.WriteLine("Removing composition " + compositions.Values[index].ToString());
            compositions.Values.RemoveAt(index);
        }
    }

    public override void Run()
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
            else if (action == "save")
            {
                RunSave();
            }
            else if (action == "load")
            {
                RunLoad();
            }
            else
            {
                PrintHelp();
            }
            Console.WriteLine("---");
        }
    }

    private void RunLoad()
    {
        int method = PromptChoice("Choose load method", ["Json", "Xml", "SQLite"]);
        string path = PromptUser("Saved file path");
        switch (method)
        {
            case 1:
                compositions = JsonSerializer.Deserialize<Compositions>(File.ReadAllText(path))!;
                break;
            case 2:
                StreamReader reader = new StreamReader(path);
                compositions = (Compositions)new XmlSerializer(typeof(Compositions)).Deserialize(reader)!;
                break;
            case 3:
                AppDbContext context = new AppDbContext(path);
                context.Database.EnsureCreated();
                compositions.Values = context.Compositions.ToList();
                break;
        }
    }

    private void RunSave()
    {
        int method = PromptChoice("Choose save method", ["Json", "Xml", "SQLite"]);
        string path = PromptUser("Saved file path");
        switch (method)
        {
            case 1:
                File.WriteAllText(path, JsonSerializer.Serialize(compositions));
                break;
            case 2:
                StreamWriter writer = new StreamWriter(path);
                new XmlSerializer(typeof(Compositions)).Serialize(writer, compositions);
                break;
            case 3:
                AppDbContext context = new AppDbContext(path);
                context.Database.EnsureCreated();
                context.Compositions.ExecuteDelete();
                context.Compositions.AddRange(compositions.Values);
                context.SaveChanges();
                break;
        }
    }
}