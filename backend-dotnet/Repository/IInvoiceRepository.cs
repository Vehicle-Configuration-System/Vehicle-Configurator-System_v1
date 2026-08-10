
using backend_dotnet.Models;

namespace backend_dotnet.Repositories
{
    public interface IInvoiceRepository
    {
        Invoice? GetById(int invoiceId);

        Invoice Save(Invoice invoice);
    }
}

