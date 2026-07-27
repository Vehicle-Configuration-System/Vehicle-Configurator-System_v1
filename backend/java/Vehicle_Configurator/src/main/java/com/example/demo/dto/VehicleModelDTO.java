package com.example.demo.dto;

public class VehicleModelDTO {

    private int modelId;
    private String modelName;

    public VehicleModelDTO() {
    }

    public VehicleModelDTO(int modelId, String modelName) {
        this.modelId = modelId;
        this.modelName = modelName;
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

}
