using PEBackup;

string[] arguments = Environment.GetCommandLineArgs();

if (!ConsoleInputValidation.ValidateInput(arguments))
{
    return;
}

string source = arguments[1];
string destination = arguments[2];
destination = ConsoleInputValidation.AppendDestination(arguments, destination);

Console.WriteLine($"Downloading data form Source: {source} to Destination: {destination}");
await BackupService.Backup(source, destination);
Console.WriteLine("Download finished");