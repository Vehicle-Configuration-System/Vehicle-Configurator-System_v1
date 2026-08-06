namespace backend_dotnet.DTO
{
    public class ConfigurationResponseDTO
    {
        public int ComponentId { get; set; }

        public string ComponentName { get; set; } = string.Empty;

        public string ComponentType {  get; set; } = string.Empty;

        public string Configurable {  get; set; } = string.Empty;
    }
}
