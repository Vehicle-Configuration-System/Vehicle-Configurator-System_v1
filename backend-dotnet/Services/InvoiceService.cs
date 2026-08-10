
using backend_dotnet.DTO;
using backend_dotnet.Models;
using backend_dotnet.Repositories;
using backend_dotnet.Repository;

namespace backend_dotnet.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository invoiceRepository;
        private readonly IInvoiceDetailRepository invoiceDetailRepository;
        private readonly IVehicleModelRepository vehicleModelRepository;
        private readonly IComponentRepository componentRepository;
        private readonly IVehicleDetailRepository vehicleDetailRepository;
        private readonly IUserRepository userRepository;
        private readonly IAlternateComponentRepository alternateComponentRepository;

        public InvoiceService(
            IInvoiceRepository invoiceRepository,
            IInvoiceDetailRepository invoiceDetailRepository,
            IVehicleModelRepository vehicleModelRepository,
            IComponentRepository componentRepository,
            IVehicleDetailRepository vehicleDetailRepository,
            IUserRepository userRepository,
            IAlternateComponentRepository alternateComponentRepository)
        {
            this.invoiceRepository = invoiceRepository;
            this.invoiceDetailRepository = invoiceDetailRepository;
            this.vehicleModelRepository = vehicleModelRepository;
            this.componentRepository = componentRepository;
            this.vehicleDetailRepository = vehicleDetailRepository;
            this.userRepository = userRepository;
            this.alternateComponentRepository = alternateComponentRepository;
        }

        public Invoice GetInvoiceById(int invoiceId)
        {
            Invoice? invoice = invoiceRepository.GetById(invoiceId);

            if (invoice == null)
            {
                throw new Exception("Invoice Not Found");
            }

            return invoice;
        }

        public InvoiceResponseDTO GetInvoice(int invoiceId)
        {
            Invoice? invoice = invoiceRepository.GetById(invoiceId);

            if (invoice == null)
            {
                throw new Exception("Invoice Not Found");
            }

            List<VehicleDetail> vehicleDetails =
                vehicleDetailRepository.GetByModelId(
                    invoice.VehicleModel.ModelId);

            List<InvoiceDetail> details =
                invoiceDetailRepository.GetByInvoiceId(invoiceId);

            List<InvoiceDetailResponseDTO> componentList =
                new List<InvoiceDetailResponseDTO>();

            foreach (VehicleDetail vd in vehicleDetails)
            {
                InvoiceDetailResponseDTO dto =
                    new InvoiceDetailResponseDTO();

                dto.ComponentName =
                    vd.Component.CompName;

                InvoiceDetail? matched = details
                    .FirstOrDefault(d =>
                        d.Component.CompId ==
                        vd.Component.CompId);

                if (matched != null)
                {
                    if (matched.AlternateComponent != null)
                    {
                        dto.SelectedComponent =
                            matched.AlternateComponent.CompName;
                    }
                    else
                    {
                        dto.SelectedComponent = "Default";
                    }

                    dto.DeltaPrice = matched.DeltaPrice;
                }
                else
                {
                    dto.SelectedComponent = "Default";
                    dto.DeltaPrice = 0;
                }

                componentList.Add(dto);
            }

            InvoiceResponseDTO response =
                new InvoiceResponseDTO();

            response.invoiceId = invoice.InvoiceId;
            response.invoiceDate = invoice.InvoiceDate;

            response.username =
                invoice.User.Username;

            response.companyName =
                invoice.User.CompanyName;

            response.companyAddress =
                invoice.User.CompanyAddress;

            response.email =
                invoice.User.Email;

            response.mobile =
                invoice.User.Mobile;

            response.gstNo =
                invoice.User.GstNo;

            response.modelName =
                invoice.VehicleModel.ModelName;

            response.manufacturer =
                invoice.VehicleModel.Manufacturer.ManufacturerName;

            response.segment =
                invoice.VehicleModel.Segment.segmentName;

            response.image =
                invoice.VehicleModel.Image;

            response.quantity =
                invoice.Quantity;

            response.totalAmount =
                invoice.TotalAmount;

            response.tax =
                invoice.Tax;

            response.finalAmount =
                invoice.FinalAmount;

            response.components =
                componentList;

            return response;
        }

        public Invoice SaveInvoice(InvoiceRequestDTO request)
        {
            VehicleModel? model =
                vehicleModelRepository.GetById(request.modelId);

            if (model == null)
            {
                throw new Exception("Vehicle Model Not Found");
            }

            User? user =
                userRepository.GetById(request.userId);

            if (user == null)
            {
                throw new Exception("User Not Found");
            }

            Invoice invoice =
                new Invoice();

            invoice.InvoiceDate =
                DateTime.Now;

            invoice.User = user;
            invoice.VehicleModel = model;

            invoice.Quantity =
                request.quantity;

            invoice.TotalAmount =
                request.totalAmount;

            invoice.Tax =
                request.tax;

            invoice.FinalAmount =
                request.finalAmount;

            Invoice savedInvoice =
                invoiceRepository.Save(invoice);

            foreach (SelectedComponentDTO detailRequest
                     in request.selectedComponents)
            {
                InvoiceDetail detail =
                    new InvoiceDetail();

                detail.Invoice =
                    savedInvoice;

                Component? component =
                    componentRepository.GetById(
                        detailRequest.componentId);

                if (component == null)
                {
                    throw new Exception("Component Not Found");
                }

                detail.Component =
                    component;

                if (detailRequest.alternateComponentId != 0)
                {
                    Component? alternate =
                        componentRepository.GetById(
                            detailRequest.alternateComponentId);

                    if (alternate == null)
                    {
                        throw new Exception(
                            "Alternate Component Not Found");
                    }

                    detail.AlternateComponent =
                        alternate;

                    AlternateComponent? alt =
                        alternateComponentRepository
                            .FindByAlternateComponent_CompIdAndComponent_CompIdAndModel_ModelId(
                                detailRequest.alternateComponentId,
                                detailRequest.componentId,
                                request.modelId);

                    if (alt == null)
                    {
                        throw new Exception(
                            "Alternate Mapping Not Found");
                    }

                    detail.DeltaPrice =
                        alt.DeltaPrice;
                }
                else
                {
                    detail.DeltaPrice = 0;
                }

                invoiceDetailRepository.Save(detail);
            }

            return savedInvoice;
        }
    }
}
