namespace backend_dotnet.DTO
{
    public class AlternateComponentDTO
    {
        public int AltId { get; set; }

        public int ComponentId { get; set; }

        public string ComponentName { get; set; } = string.Empty;

        public float DeltaPrice { get; set; }
    }
}
