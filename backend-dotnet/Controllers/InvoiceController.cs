
using backend_dotnet.DTO;
using backend_dotnet.Models;
using backend_dotnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend_dotnet.Controllers
{
    [ApiController]
    [Route("api/invoice")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            this.invoiceService = invoiceService;
        }

        [HttpPost("generate")]
        public ActionResult GenerateInvoice(
    [FromBody] InvoiceRequestDTO request)
        {
            Invoice invoice = invoiceService.SaveInvoice(request);

            return Ok(new
            {
                invoiceId = invoice.InvoiceId
            });
        }

        [HttpGet("{invoiceId:int}")]
        public ActionResult<InvoiceResponseDTO> GetInvoice(
            int invoiceId)
        {
            return invoiceService.GetInvoice(invoiceId);
        }
    }
}

