namespace Isoide.Infrastructure.DataAccess;

public class IsoideDatabaseSettings
{
	public string ConnectionString { get; set; } = null!;
	public string DatabaseName { get; set; } = null!;
	public string QrCodeCollectionName { get; set; } = null!;
}