package com.example.demo.controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import com.example.demo.dto.InvoiceRequestDTO;
import com.example.demo.dto.InvoiceResponseDTO;
import com.example.demo.entities.Invoice;
import com.example.demo.services.InvoiceService;

@RestController
@RequestMapping("/api/invoice")
@CrossOrigin(origins = "http://localhost:5173")
public class InvoiceController {

    @Autowired
    private InvoiceService invoiceService;


    @PostMapping("/generate")
    public Invoice generateInvoice(@RequestBody InvoiceRequestDTO request) {

        return invoiceService.saveInvoice(request);
    }
    @GetMapping("/{invoiceId}")
    public InvoiceResponseDTO getInvoice(
            @PathVariable int invoiceId){

        return invoiceService.getInvoice(invoiceId);

    }
}
