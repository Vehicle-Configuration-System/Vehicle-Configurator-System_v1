package com.example.demo.dto;

public class AlternateComponentDTO {

    private int altId;
    private int componentId;
    private String componentName;
    private float deltaPrice;

    public AlternateComponentDTO() {
    }

    public AlternateComponentDTO(int altId, int componentId,
            String componentName, float deltaPrice) {

        this.altId = altId;
        this.componentId = componentId;
        this.componentName = componentName;
        this.deltaPrice = deltaPrice;
    }

    public int getAltId() {
        return altId;
    }

    public void setAltId(int altId) {
        this.altId = altId;
    }

    public int getComponentId() {
        return componentId;
    }

    public void setComponentId(int componentId) {
        this.componentId = componentId;
    }

    public String getComponentName() {
        return componentName;
    }

    public void setComponentName(String componentName) {
        this.componentName = componentName;
    }

    public float getDeltaPrice() {
        return deltaPrice;
    }

    public void setDeltaPrice(float deltaPrice) {
        this.deltaPrice = deltaPrice;
    }
}