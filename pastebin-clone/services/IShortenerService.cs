namespace pastebin_clone_2.services;

public interface IShortenerService
{

    public string GenerateShortString(int seed);
    public int RestoreSeedFromString(string str);

}