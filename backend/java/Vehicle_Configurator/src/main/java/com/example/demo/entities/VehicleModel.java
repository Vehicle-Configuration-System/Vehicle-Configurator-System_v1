package com.example.demo.entities;

import jakarta.persistence.*;

@Entity
@Table(name = "vehicle_model")
public class VehicleModel {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "model_id")
    private int modelId;

    @ManyToOne
    @JoinColumn(name = "manufacturer_id")
    private Manufacturer manufacturer;

    @ManyToOne
    @JoinColumn(name = "segment_id")
    private Segment segment;

    @Column(name = "model_name", nullable = false, length = 100)
    private String modelName;

    @Column(name = "image", nullable = false, length = 100)
    private String image;

    @Column(name = "base_price", nullable = false)
    private float basePrice;

    @Column(name = "minimum_quantity", nullable = false)
    private int minimumQuantity;

    public VehicleModel() {
    }

    public VehicleModel(int modelId, Manufacturer manufacturer, Segment segment, String modelName,
            String image, float basePrice, int minimumQuantity) {
        this.modelId = modelId;
        this.manufacturer = manufacturer;
        this.segment = segment;
        this.modelName = modelName;
        this.image = image;
        this.basePrice = basePrice;
        this.minimumQuantity = minimumQuantity;
    }

    public int getModelId() {
        return modelId;
    }

    public void setModelId(int modelId) {
        this.modelId = modelId;
    }

    public Manufacturer getManufacturer() {
        return manufacturer;
    }

    public void setManufacturer(Manufacturer manufacturer) {
        this.manufacturer = manufacturer;
    }

    public Segment getSegment() {
        return segment;
    }

    public void setSegment(Segment segment) {
        this.segment = segment;
    }

    public String getModelName() {
        return modelName;
    }

    public void setModelName(String modelName) {
        this.modelName = modelName;
    }

    public String getImage() {
        return image;
    }

    public void setImage(String image) {
        this.image = image;
    }

    public float getBasePrice() {
        return basePrice;
    }

    public void setBasePrice(float basePrice) {
        this.basePrice = basePrice;
    }

    public int getMinimumQuantity() {
        return minimumQuantity;
    }

    public void setMinimumQuantity(int minimumQuantity) {
        this.minimumQuantity = minimumQuantity;
    }

}
