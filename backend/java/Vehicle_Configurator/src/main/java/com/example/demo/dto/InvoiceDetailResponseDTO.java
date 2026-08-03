package com.example.demo.dto;


public class InvoiceDetailResponseDTO {

    private String componentName;

    private String selectedComponent;

    private double deltaPrice;

	public String getComponentName() {
		return componentName;
	}

	public void setComponentName(String componentName) {
		this.componentName = componentName;
	}

	public String getSelectedComponent() {
		return selectedComponent;
	}

	public void setSelectedComponent(String selectedComponent) {
		this.selectedComponent = selectedComponent;
	}

	public double getDeltaPrice() {
		return deltaPrice;
	}

	public void setDeltaPrice(double deltaPrice) {
		this.deltaPrice = deltaPrice;
	}

    
}