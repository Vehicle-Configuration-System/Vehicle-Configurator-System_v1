package com.example.demo.entities;



import jakarta.persistence.*;

@Entity
@Table(name = "vehicle_detail")
public class VehicleDetail {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "config_id")
    private int configId;

    @ManyToOne
    @JoinColumn(name = "model_id")
    private VehicleModel model;

    @ManyToOne
    @JoinColumn(name = "comp_id")
    private Component component;

    @Column(name = "comp_type", nullable = false)
    private String compType;

    @Column(name = "is_configurable", nullable = false)
    private String isConfigurable;

    public VehicleDetail() {
    }

    public VehicleDetail(int configId, VehicleModel model,
            Component component, String compType,
            String isConfigurable) {

        this.configId = configId;
        this.model = model;
        this.component = component;
        this.compType = compType;
        this.isConfigurable = isConfigurable;
    }

    public int getConfigId() {
        return configId;
    }

    public void setConfigId(int configId) {
        this.configId = configId;
    }

    public VehicleModel getModel() {
        return model;
    }

    public void setModel(VehicleModel model) {
        this.model = model;
    }

    public Component getComponent() {
        return component;
    }

    public void setComponent(Component component) {
        this.component = component;
    }

    public String getCompType() {
        return compType;
    }

    public void setCompType(String compType) {
        this.compType = compType;
    }

    public String getIsConfigurable() {
        return isConfigurable;
    }

    public void setIsConfigurable(String isConfigurable) {
        this.isConfigurable = isConfigurable;
    }

}
