package com.example.demo.entities;

import jakarta.persistence.*;

@Entity
@Table(name = "segment_master")
public class Segment {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int segmentId;

    private String segmentName;

    // Getters and Setters
}