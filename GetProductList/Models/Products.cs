using Azure;
using Azure.Data.Tables;

namespace GetProductList.Models
{
    public class Products : ITableEntity
    {
        public string PartitionKey { get; set; } = string.Empty;
        public string RowKey { get; set; } = string.Empty;
        public DateTimeOffset? Timestamp { get; set; }
        public string Image { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ETag ETag { get; set; }
    }
}
