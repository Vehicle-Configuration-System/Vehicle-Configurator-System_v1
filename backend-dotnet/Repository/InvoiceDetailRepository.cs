using backend_dotnet.Data;
using backend_dotnet.Models;
using backend_dotnet.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet.Repository
{
    public class InvoiceDetailRepository : IInvoiceDetailRepository
    {
        private readonly ApplicationDbContext _context;

        public InvoiceDetailRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<InvoiceDetail> GetByInvoiceId(int invoiceId)
        {
            return _context.InvoiceDetails
                .Where(d => d.InvoiceId == invoiceId)
                .Include(d => d.Component)
                .Include(d => d.AlternateComponent)
                .ToList();
        }

        public InvoiceDetail Save(InvoiceDetail invoiceDetail)
        {
            _context.InvoiceDetails.Add(invoiceDetail);
            _context.SaveChanges();

            return invoiceDetail;
        }
    }
}

