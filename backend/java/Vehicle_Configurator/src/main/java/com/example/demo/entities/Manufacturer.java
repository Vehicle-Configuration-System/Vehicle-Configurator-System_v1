package com.example.demo.entities;

import jakarta.persistence.*;
import java.util.List;

@Entity
@Table(name = "manufacturer_master")
public class Manufacturer {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int manufacturerId;

    private String manufacturerName;

    @ManyToMany
    @JoinTable(
            name = "segment_manufacturer",
            joinColumns = @JoinColumn(name = "manufacturer_id"),
            inverseJoinColumns = @JoinColumn(name = "segment_id")
    )
    private List<Segment> segments;

    // Getters and Setters
}