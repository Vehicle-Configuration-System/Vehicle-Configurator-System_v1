package com.example.demo.dto;

public class ComponentInfoDTO {


    private int configId;

    private String componentName;

    private String componentType;

    private String configurable;



    public int getConfigId() {
        return configId;
    }


    public void setConfigId(int configId) {
        this.configId = configId;
    }


    public String getComponentName() {
        return componentName;
    }


    public void setComponentName(String componentName) {
        this.componentName = componentName;
    }


    public String getComponentType() {
        return componentType;
    }


    public void setComponentType(String componentType) {
        this.componentType = componentType;
    }


    public String getConfigurable() {
        return configurable;
    }


    public void setConfigurable(String configurable) {
        this.configurable = configurable;
    }

}