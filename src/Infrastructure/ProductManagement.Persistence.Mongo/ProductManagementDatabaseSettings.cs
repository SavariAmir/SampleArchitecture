namespace ProductManagement.Persistence.Mongo
{
    public class ProductManagementDatabaseSettings : IProductManagementDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}