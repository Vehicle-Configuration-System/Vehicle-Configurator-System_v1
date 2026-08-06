namespace backend_dotnet.DTO
{
    public class VehicleInfoDTO
    {
        public int ModelId { get; set; }

        public string ModelName { get; set; } = string.Empty;

        public string Image { get; set; } = string.Empty;

        public string Manufacturer { get; set; } = string.Empty;

        public string Segment { get; set; } = string.Empty;

        public double BasePrice { get; set; }
    }
}
