namespace supplierBackendAPIs.Utilities
{
    public class AzureBlobSettings
    {
        public string ? accountName { get; set; }
        public string ? containerName { get; set; }
        public string? sasToken { get; set; }
        public string? sasUrl { get; set; }
    }
}
