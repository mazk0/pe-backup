using PEBackup;

var arguments = Environment.GetCommandLineArgs();

if (!ConsoleInputValidation.ValidateInput(arguments))
{
    return;
}

var source = arguments[1];
var destination = arguments[2];
destination = ConsoleInputValidation.AppendDestination(arguments, destination);

Console.WriteLine($"Downloading data form Source: {source} to Destination: {destination}");
await BackupService.Backup(source, destination);
Console.WriteLine("Download finished");