namespace PEBackup;

public static class ConsoleInputValidation
{
    public static bool ValidateInput(string[] arguments)
    {
        if (arguments.Length < 3)
        {
            Console.WriteLine("Not enough arguments");
            WriteExample();
            
            return false;
        }

        if (!Uri.TryCreate(arguments[1], UriKind.Absolute, out _))
        {
            Console.WriteLine("Source is not a valid URI");
            WriteExample();
            
            return false;
        }

        return true;
    }
    
    public static string AppendDestination(IReadOnlyList<string> arguments, string source)
    {
        if (arguments.Count == 4 && bool.TryParse(arguments[3], out bool addDateToFileName) && addDateToFileName)
        {
            return source.Insert(source.LastIndexOf('.'), $"_{DateTime.Now:yyyy-MM-dd}");
        }

        return source;
    }
    
    private static void WriteExample()
    {
        Console.WriteLine("Usage: dotnet run <source:string> <destination:string> <IncludeDateInFileName:bool !optional!>");
        Console.WriteLine("Example: dotnet run --configuration Release https://pe.makra.dev/api/event/getall /Volumes/Temp/PolisenSeEvents_Backup/backup.json true");
    }
}