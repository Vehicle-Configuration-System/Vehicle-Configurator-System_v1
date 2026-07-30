package com.example.demo.entities;

import jakarta.persistence.*;

@Entity
@Table(name = "invoice_detail")
public class InvoiceDetail {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int invoiceDetailId;

    @ManyToOne
    @JoinColumn(name = "invoice_id")
    private Invoice invoice;

    @ManyToOne
    @JoinColumn(name = "component_id")
    private Component component;

    private double componentPrice;

    // Getters and Setters
}