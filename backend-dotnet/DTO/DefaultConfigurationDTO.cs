namespace backend_dotnet.DTO
{
    public class DefaultConfigurationDTO
    {
        public VehicleInfoDTO Vehicle { get; set; } = new();

        public List<ComponentInfoDTO> Components { get; set; } = new();
    }
}
