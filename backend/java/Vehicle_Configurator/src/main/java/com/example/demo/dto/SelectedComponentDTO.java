package com.example.demo.dto;

public class SelectedComponentDTO {

    private Integer componentId;
    private Integer alternateComponentId;
    private double deltaPrice;

    public SelectedComponentDTO() {
    }

    public int getComponentId() {
        return componentId;
    }

    public void setComponentId(int componentId) {
        this.componentId = componentId;
    }

    public int getAlternateComponentId() {
        return alternateComponentId;
    }

    public void setAlternateComponentId(int alternateComponentId) {
        this.alternateComponentId = alternateComponentId;
    }

    public double getDeltaPrice() {
        return deltaPrice;
    }

    public void setDeltaPrice(double deltaPrice) {
        this.deltaPrice = deltaPrice;
    }
}