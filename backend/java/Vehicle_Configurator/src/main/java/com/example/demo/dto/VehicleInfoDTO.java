package com.example.demo.dto;



public class VehicleInfoDTO {


    private int modelId;

    private String modelName;

    private String image;

    private String manufacturer;

    private String segment;

    private double basePrice;



    public int getModelId() {
        return modelId;
    }


    public void setModelId(int modelId) {
        this.modelId = modelId;
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


    public String getManufacturer() {
        return manufacturer;
    }


    public void setManufacturer(String manufacturer) {
        this.manufacturer = manufacturer;
    }


    public String getSegment() {
        return segment;
    }


    public void setSegment(String segment) {
        this.segment = segment;
    }


    public double getBasePrice() {
        return basePrice;
    }


    public void setBasePrice(double basePrice) {
        this.basePrice = basePrice;
    }

}