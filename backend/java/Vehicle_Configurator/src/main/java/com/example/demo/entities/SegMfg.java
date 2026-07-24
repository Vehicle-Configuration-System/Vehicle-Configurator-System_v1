package com.example.demo.entities;

import jakarta.persistence.*;

@Entity
@Table(name = "seg_mfg_master")
public class SegMfg {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "seg_mfg_id")
    private int segMfgId;

    @ManyToOne
    @JoinColumn(name = "segment_id")
    private Segment segment;

    @ManyToOne
    @JoinColumn(name = "manufacturer_id")
    private Manufacturer manufacturer;

    public SegMfg() {
    }

    public SegMfg(int segMfgId, Segment segment, Manufacturer manufacturer) {
        this.segMfgId = segMfgId;
        this.segment = segment;
        this.manufacturer = manufacturer;
    }

    public int getSegMfgId() {
        return segMfgId;
    }

    public void setSegMfgId(int segMfgId) {
        this.segMfgId = segMfgId;
    }

    public Segment getSegment() {
        return segment;
    }

    public void setSegment(Segment segment) {
        this.segment = segment;
    }

    public Manufacturer getManufacturer() {
        return manufacturer;
    }

    public void setManufacturer(Manufacturer manufacturer) {
        this.manufacturer = manufacturer;
    }
}