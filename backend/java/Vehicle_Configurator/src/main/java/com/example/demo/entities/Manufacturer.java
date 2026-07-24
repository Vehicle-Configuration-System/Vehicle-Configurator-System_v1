package com.example.demo.entities;

import jakarta.persistence.*;

@Entity
@Table(name = "manufacturer_master")
public class Manufacturer {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "manufacturer_id")
    private int manufacturerId;

    @Column(name = "manufacturer_name")
    private String manufacturerName;

    public Manufacturer() {
    }

    public Manufacturer(int manufacturerId, String manufacturerName) {
        this.manufacturerId = manufacturerId;
        this.manufacturerName = manufacturerName;
    }

    public int getManufacturerId() {
        return manufacturerId;
    }

    public void setManufacturerId(int manufacturerId) {
        this.manufacturerId = manufacturerId;
    }

    public String getManufacturerName() {
        return manufacturerName;
    }

    public void setManufacturerName(String manufacturerName) {
        this.manufacturerName = manufacturerName;
    }
}