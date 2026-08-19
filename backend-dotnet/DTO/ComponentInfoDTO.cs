namespace backend_dotnet.DTO
{
    public class ComponentInfoDTO
    {
        public int ConfigId { get; set; }

        public string ComponentName { get; set; } = string.Empty;

        public string ComponentType { get; set; } = string.Empty;

        public string Configurable { get; set; } = string.Empty;
    }
}
