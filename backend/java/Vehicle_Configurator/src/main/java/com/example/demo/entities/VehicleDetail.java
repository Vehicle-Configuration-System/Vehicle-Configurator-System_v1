package com.example.demo.entities;

import jakarta.persistence.*;

@Entity
@Table(name = "vehicle_detail")
public class VehicleDetail {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int vehicleDetailId;

    @ManyToOne
    @JoinColumn(name = "model_id")
    private Model model;

    @ManyToOne
    @JoinColumn(name = "component_id")
    private Component component;

    // Getters and Setters
}