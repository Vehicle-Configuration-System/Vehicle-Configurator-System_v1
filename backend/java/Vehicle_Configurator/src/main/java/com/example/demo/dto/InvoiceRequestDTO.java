package com.example.demo.dto;

import java.util.List;

public class InvoiceRequestDTO {

    private int modelId;
    private int quantity;
    private double totalAmount;
    private double tax;
    private double finalAmount;
    private int userId;
    public int getUserId() {
		return userId;
	}

	public void setUserId(int userId) {
		this.userId = userId;
	}

	private List<SelectedComponentDTO> selectedComponents;

    public InvoiceRequestDTO() {
    }

    public int getModelId() {
        return modelId;
    }

    public void setModelId(int modelId) {
        this.modelId = modelId;
    }

    public int getQuantity() {
        return quantity;
    }

    public void setQuantity(int quantity) {
        this.quantity = quantity;
    }

    public double getTotalAmount() {
        return totalAmount;
    }

    public void setTotalAmount(double totalAmount) {
        this.totalAmount = totalAmount;
    }

    public double getTax() {
        return tax;
    }

    public void setTax(double tax) {
        this.tax = tax;
    }

    public double getFinalAmount() {
        return finalAmount;
    }

    public void setFinalAmount(double finalAmount) {
        this.finalAmount = finalAmount;
    }

    public List<SelectedComponentDTO> getSelectedComponents() {
        return selectedComponents;
    }

    public void setSelectedComponents(List<SelectedComponentDTO> selectedComponents) {
        this.selectedComponents = selectedComponents;
    }
}