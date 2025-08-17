namespace Payment.DAL.Options
{
    public class MongoOptions
    {
        public string ConnectionString { get; set; } = default!;
        public string DatabaseName { get; set; } = default!;
        public string ReceiptsCollectionName { get; set; } = default!;
    }
}
