package com.example.demo.entities;

import jakarta.persistence.*;

@Entity
@Table(name = "invoice_detail")
public class InvoiceDetail {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "invoice_detail_id")
    private int invoiceDetailId;

    @ManyToOne
    @JoinColumn(name = "invoice_id")
    private Invoice invoice;

    // Original Component
    @ManyToOne
    @JoinColumn(name = "component_id")
    private Component component;

    // Selected Alternative Component
    @ManyToOne
    @JoinColumn(name = "alternate_component_id")
    private Component alternateComponent;

    @Column(name = "delta_price")
    private double deltaPrice;

    public InvoiceDetail() {
    }

    public int getInvoiceDetailId() {
        return invoiceDetailId;
    }

    public void setInvoiceDetailId(int invoiceDetailId) {
        this.invoiceDetailId = invoiceDetailId;
    }

    public Invoice getInvoice() {
        return invoice;
    }

    public void setInvoice(Invoice invoice) {
        this.invoice = invoice;
    }

    public Component getComponent() {
        return component;
    }

    public void setComponent(Component component) {
        this.component = component;
    }

    public Component getAlternateComponent() {
        return alternateComponent;
    }

    public void setAlternateComponent(Component alternateComponent) {
        this.alternateComponent = alternateComponent;
    }

    public double getDeltaPrice() {
        return deltaPrice;
    }

    public void setDeltaPrice(double deltaPrice) {
        this.deltaPrice = deltaPrice;
    }
}