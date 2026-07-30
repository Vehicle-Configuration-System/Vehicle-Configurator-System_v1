package com.example.demo.entities;

import jakarta.persistence.*;

@Entity
@Table(name = "invoice_master")
public class Invoice {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int invoiceId;

    @ManyToOne
    @JoinColumn(name = "user_id")
    private User user;

    @ManyToOne
    @JoinColumn(name = "model_id")
    private Model model;

    private int quantity;

    private double totalAmount;

    // Getters and Setters
}