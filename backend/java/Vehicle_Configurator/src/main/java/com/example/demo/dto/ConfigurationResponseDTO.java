package com.example.demo.dto;

public class ConfigurationResponseDTO {

    private int componentId;
    private String componentName;
    private String componentType;
    private String configurable;

    public ConfigurationResponseDTO() {
    }

    public ConfigurationResponseDTO(int componentId,
                                    String componentName,
                                    String componentType,
                                    String configurable) {

        this.componentId = componentId;
        this.componentName = componentName;
        this.componentType = componentType;
        this.configurable = configurable;
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
