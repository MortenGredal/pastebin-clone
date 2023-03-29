namespace pastebin_clone_2.models;

public class PastebinConnectionSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string PastesCollectionName { get; set; } = null!;
}
