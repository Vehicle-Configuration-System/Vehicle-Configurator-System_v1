
using backend_dotnet.Data;
using backend_dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationDbContext _context;

        public InvoiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Invoice? GetById(int invoiceId)
        {
            return _context.Invoices
        .Include(i => i.VehicleModel)
            .ThenInclude(vm => vm.Manufacturer)
        .Include(i => i.VehicleModel)
            .ThenInclude(vm => vm.Segment)
        .Include(i => i.User)
        .FirstOrDefault(i => i.InvoiceId == invoiceId);
        }

        public Invoice Save(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            _context.SaveChanges();

            return invoice;
        }
    }
}
