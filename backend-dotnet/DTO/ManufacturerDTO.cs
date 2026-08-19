namespace backend_dotnet.DTO
{
    public class ManufacturerDTO
    {

        public int ManufacturerId { get; set; }

        public string ManufacturerName { get; set; }


        public ManufacturerDTO()
        {
        }


        public ManufacturerDTO(int manufacturerId, string manufacturerName)
        {
            ManufacturerId = manufacturerId;
            ManufacturerName = manufacturerName;
        }
    }
}
