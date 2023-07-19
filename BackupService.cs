namespace PEBackup;

public static class BackupService
{
    private static readonly HttpClient Client = new();
    
    public static async Task Backup(string sourceUrl, string destinationPath)
    {
        await using Stream responseStream = await Client.GetStreamAsync(sourceUrl);
        await using Stream streamToWriteTo = File.Open(destinationPath, FileMode.Create);
        await responseStream.CopyToAsync(streamToWriteTo);
    }
}