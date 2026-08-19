package com.example.demo.dto;

public class VehicleModelDTO {

    private int modelId;
    private String modelName;
    private int minimumQuantity;

    public VehicleModelDTO() {
    }

    public VehicleModelDTO(int modelId, String modelName, int minimumQuantity) {
        this.modelId = modelId;
        this.modelName = modelName;
        this.minimumQuantity = minimumQuantity;
    }

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

    public int getMinimumQuantity() {
        return minimumQuantity;
    }

    public void setMinimumQuantity(int minimumQuantity) {
        this.minimumQuantity = minimumQuantity;
    }
}