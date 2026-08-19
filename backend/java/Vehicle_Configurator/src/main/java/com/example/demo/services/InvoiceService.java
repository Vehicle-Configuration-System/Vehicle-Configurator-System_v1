package com.example.demo.services;

import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.demo.dto.InvoiceDetailResponseDTO;
import com.example.demo.dto.InvoiceRequestDTO;
import com.example.demo.dto.InvoiceResponseDTO;
import com.example.demo.dto.SelectedComponentDTO;
import com.example.demo.entities.AlternateComponent;
import com.example.demo.entities.Component;
import com.example.demo.entities.Invoice;
import com.example.demo.entities.InvoiceDetail;
import com.example.demo.entities.User;
import com.example.demo.entities.VehicleDetail;
import com.example.demo.entities.VehicleModel;
import com.example.demo.repositories.AlternateComponentRepository;
import com.example.demo.repositories.ComponentRepository;
import com.example.demo.repositories.InvoiceDetailRepository;
import com.example.demo.repositories.InvoiceRepository;
import com.example.demo.repositories.UserRepository;
import com.example.demo.repositories.VehicleDetailRepository;
import com.example.demo.repositories.VehicleModelRepository;

@Service
public class InvoiceService {

    @Autowired
    private InvoiceRepository invoiceRepository;

    @Autowired
    private InvoiceDetailRepository invoiceDetailRepository;

    @Autowired
    private VehicleModelRepository vehicleModelRepository;

    @Autowired
    private ComponentRepository componentRepository;
    @Autowired
    private VehicleDetailRepository vehicleDetailRepository;
    @Autowired
    private UserRepository userRepository;
    @Autowired
    private AlternateComponentRepository alternateComponentRepository;
    public Invoice getInvoiceById(int invoiceId) {

        return invoiceRepository
                .findById(invoiceId)
                .orElseThrow(() ->
                        new RuntimeException("Invoice Not Found"));

    }
    public InvoiceResponseDTO getInvoice(int invoiceId) {

        Invoice invoice = invoiceRepository.findById(invoiceId)
                .orElseThrow(() -> new RuntimeException("Invoice Not Found"));
        List<VehicleDetail> vehicleDetails =
                vehicleDetailRepository.findByModel_ModelId(
                        invoice.getVehicleModel().getModelId());

        List<InvoiceDetail> details =
                invoiceDetailRepository.findByInvoiceInvoiceId(invoiceId);
        List<InvoiceDetailResponseDTO> componentList =
                new ArrayList<>();

        for (VehicleDetail vd : vehicleDetails) {

            InvoiceDetailResponseDTO dto = new InvoiceDetailResponseDTO();

            dto.setComponentName(vd.getComponent().getCompName());

            InvoiceDetail matched = details.stream()
                    .filter(d -> d.getComponent().getCompId()
                            == vd.getComponent().getCompId())
                    .findFirst()
                    .orElse(null);

            if (matched != null) {

                if (matched.getAlternateComponent() != null) {

                    dto.setSelectedComponent(
                            matched.getAlternateComponent().getCompName());

                } else {

                    dto.setSelectedComponent("Default");

                }

                dto.setDeltaPrice(matched.getDeltaPrice());

            } else {

                dto.setSelectedComponent("Default");
                dto.setDeltaPrice(0);

            }

            componentList.add(dto);
        }
        InvoiceResponseDTO response =
                new InvoiceResponseDTO();

        response.setInvoiceId(invoice.getInvoiceId());

        response.setInvoiceDate(invoice.getInvoiceDate());

        response.setUsername(
                invoice.getUser().getUsername());

        response.setCompanyName(
                invoice.getUser().getCompanyName());

        response.setCompanyAddress(
                invoice.getUser().getCompanyAddress());

        response.setEmail(
                invoice.getUser().getEmail());

        response.setMobile(
                invoice.getUser().getMobile());

        response.setGstNo(
                invoice.getUser().getGstNo());

        response.setModelName(
                invoice.getVehicleModel().getModelName());

        response.setManufacturer(
                invoice.getVehicleModel()
                .getManufacturer()
                .getManufacturerName());

        response.setSegment(
                invoice.getVehicleModel()
                .getSegment()
                .getSegmentName());

        response.setImage(
                invoice.getVehicleModel().getImage());

        response.setQuantity(invoice.getQuantity());

        response.setTotalAmount(invoice.getTotalAmount());

        response.setTax(invoice.getTax());

        response.setFinalAmount(invoice.getFinalAmount());

        response.setComponents(componentList);

        return response;

    }
    public Invoice saveInvoice(InvoiceRequestDTO request) {


        // Fetch Vehicle Model
        VehicleModel model = vehicleModelRepository
                .findById(request.getModelId())
                .orElseThrow(() -> new RuntimeException("Vehicle Model Not Found"));


        // Fetch User
        User user = userRepository
                .findById(request.getUserId())
                .orElseThrow(() -> new RuntimeException("User Not Found"));


        // Create Invoice
        Invoice invoice = new Invoice();

        invoice.setInvoiceDate(LocalDateTime.now());
        invoice.setUser(user);
        invoice.setVehicleModel(model);

        invoice.setQuantity(request.getQuantity());
        invoice.setTotalAmount(request.getTotalAmount());
        invoice.setTax(request.getTax());
        invoice.setFinalAmount(request.getFinalAmount());


        // Save Invoice First
        Invoice savedInvoice = invoiceRepository.save(invoice);



        // Save Invoice Details

        for (SelectedComponentDTO detailRequest : request.getSelectedComponents()) {


            InvoiceDetail detail = new InvoiceDetail();

            detail.setInvoice(savedInvoice);



            Component component = componentRepository
                    .findById(detailRequest.getComponentId())
                    .orElseThrow(() -> new RuntimeException("Component Not Found"));


            detail.setComponent(component);



            if(detailRequest.getAlternateComponentId() != 0) {


                Component alternate = componentRepository
                        .findById(detailRequest.getAlternateComponentId())
                        .orElseThrow(() -> 
                            new RuntimeException("Alternate Component Not Found"));


                detail.setAlternateComponent(alternate);

                AlternateComponent alt =
                		alternateComponentRepository
                		.findByAlternateComponent_CompIdAndComponent_CompIdAndModel_ModelId(
                		        detailRequest.getAlternateComponentId(),
                		        detailRequest.getComponentId(),
                		        request.getModelId()
                		);

                		if (alt == null) {
                		    throw new RuntimeException("Alternate Mapping Not Found");
                		}

                		detail.setDeltaPrice(alt.getDeltaPrice());
            }
            else {

                detail.setDeltaPrice(0);

            }
            invoiceDetailRepository.save(detail);

        }


        return savedInvoice;
    }

}