
using System;
using System.Collections.Generic;

namespace backend_dotnet.DTO
{
    public class InvoiceResponseDTO
    {
        public int invoiceId { get; set; }

        public DateTime invoiceDate { get; set; }

        public string username { get; set; }

        public string companyName { get; set; }

        public string companyAddress { get; set; }

        public string email { get; set; }

        public string mobile { get; set; }

        public string gstNo { get; set; }

        public string modelName { get; set; }

        public string manufacturer { get; set; }

        public string segment { get; set; }

        public string image { get; set; }

        public int quantity { get; set; }

        public double totalAmount { get; set; }

        public double tax { get; set; }

        public double finalAmount { get; set; }

        public List<InvoiceDetailResponseDTO> components { get; set; }
    }
}

