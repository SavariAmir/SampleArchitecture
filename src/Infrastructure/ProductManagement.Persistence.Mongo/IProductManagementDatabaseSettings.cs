namespace ProductManagement.Persistence.Mongo
{
    public interface IProductManagementDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}