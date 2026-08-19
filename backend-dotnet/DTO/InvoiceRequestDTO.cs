
using System.Collections.Generic;

namespace backend_dotnet.DTO
{
    public class InvoiceRequestDTO
    {
        public int modelId { get; set; }

        public int quantity { get; set; }

        public double totalAmount { get; set; }

        public double tax { get; set; }

        public double finalAmount { get; set; }

        public int userId { get; set; }

        public List<SelectedComponentDTO> selectedComponents { get; set; }
    }
}
