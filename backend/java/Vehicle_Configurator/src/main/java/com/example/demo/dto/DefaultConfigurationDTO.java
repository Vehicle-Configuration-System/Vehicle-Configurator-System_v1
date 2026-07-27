package com.example.demo.dto;


import java.util.List;


public class DefaultConfigurationDTO {


    private VehicleInfoDTO vehicle;

    private List<ComponentInfoDTO> components;


    public VehicleInfoDTO getVehicle() {
        return vehicle;
    }


    public void setVehicle(VehicleInfoDTO vehicle) {
        this.vehicle = vehicle;
    }


    public List<ComponentInfoDTO> getComponents() {
        return components;
    }


    public void setComponents(List<ComponentInfoDTO> components) {
        this.components = components;
    }

}
