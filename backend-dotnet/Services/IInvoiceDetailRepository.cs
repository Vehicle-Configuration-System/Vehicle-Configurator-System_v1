
using backend_dotnet.Models;

namespace backend_dotnet.Repositories
{
    public interface IInvoiceDetailRepository
    {
        List<InvoiceDetail> GetByInvoiceId(int invoiceId);

        InvoiceDetail Save(InvoiceDetail invoiceDetail);
    }
}

