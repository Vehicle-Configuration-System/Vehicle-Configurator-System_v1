
using backend_dotnet.DTO;
using backend_dotnet.Models;

namespace backend_dotnet.Services
{
    public interface IInvoiceService
    {
        Invoice GetInvoiceById(int invoiceId);

        InvoiceResponseDTO GetInvoice(int invoiceId);

        Invoice SaveInvoice(InvoiceRequestDTO request);
    }
}
