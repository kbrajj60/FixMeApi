namespace FixMeApi.Models;

public class MobileStoreDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string MobileCollectionName { get; set; } = null!;
}