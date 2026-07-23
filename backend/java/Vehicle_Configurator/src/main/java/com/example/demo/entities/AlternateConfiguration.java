package com.example.demo.entities;

import jakarta.persistence.*;

@Entity
@Table(name = "alternate_configuration_master")
public class AlternateConfiguration {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int altConfigId;

    @ManyToOne
    @JoinColumn(name = "model_id")
    private Model model;

    @ManyToOne
    @JoinColumn(name = "component_id")
    private Component component;

    @ManyToOne
    @JoinColumn(name = "alternate_component_id")
    private Component alternateComponent;

    private double priceDifference;

    // Getters and Setters
}
