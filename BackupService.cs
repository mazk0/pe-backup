namespace PEBackup;

public static class BackupService
{
    public static async Task Backup(string sourceUrl, string destinationPath)
    {
        var client = new HttpClient();
        var responseStream = await client.GetStreamAsync(sourceUrl);
        await using Stream streamToWriteTo = File.Open(destinationPath, FileMode.Create);
        await responseStream.CopyToAsync(streamToWriteTo);
    }
}