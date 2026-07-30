package com.example.demo.entities;

import jakarta.persistence.*;

@Entity
@Table(name="model_master")
public class Model {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer modelId;

    private String mdlName;

    @ManyToOne
    @JoinColumn(name="sm_id")
    private SegmentManufacturer segmentManufacturer;

    private Double minQtyPrice;

    private String imagePath;
}