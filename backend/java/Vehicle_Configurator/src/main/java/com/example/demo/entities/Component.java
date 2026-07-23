package com.example.demo.entities;

import jakarta.persistence.*;

@Entity
@Table(name = "component_master")
public class Component {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int componentId;

    private String componentName;

    // Getters and Setters
}
