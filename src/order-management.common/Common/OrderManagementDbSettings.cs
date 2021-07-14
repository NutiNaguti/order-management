namespace order_management.common.Common
{
    public class OrderManagementDatabaseSettings : IOrderManagementDatabaseSettings
    {
        public string OrderCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IOrderManagementDatabaseSettings
    {
        string OrderCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}