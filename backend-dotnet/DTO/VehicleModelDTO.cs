namespace backend_dotnet.DTO
{
    public class VehicleModelDTO
    {
        public int ModelId { get; set; }
        
        public string ModelName { get; set; }

        public int MinimumQuantity { get; set; }

        public VehicleModelDTO() { }

        public VehicleModelDTO(int modelId, string modelName, int minimumQuantity)
        {
            ModelId = modelId;
            ModelName = modelName;
            MinimumQuantity = minimumQuantity;
        }
    }
}
