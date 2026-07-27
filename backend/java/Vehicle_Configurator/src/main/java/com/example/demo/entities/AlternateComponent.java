package com.example.demo.entities;


import jakarta.persistence.*;

@Entity
@Table(name = "alternate_component")
public class AlternateComponent {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "alt_id")
    private int altId;

    @ManyToOne
    @JoinColumn(name = "model_id")
    private VehicleModel model;

    @ManyToOne
    @JoinColumn(name = "comp_id")
    private Component component;

    @ManyToOne
    @JoinColumn(name = "alt_comp_id")
    private Component alternateComponent;

    @Column(name = "delta_price", nullable = false)
    private float deltaPrice;

    public AlternateComponent() {
    }

    public AlternateComponent(int altId,
            VehicleModel model,
            Component component,
            Component alternateComponent,
            float deltaPrice) {

        this.altId = altId;
        this.model = model;
        this.component = component;
        this.alternateComponent = alternateComponent;
        this.deltaPrice = deltaPrice;
    }

    public int getAltId() {
        return altId;
    }

    public void setAltId(int altId) {
        this.altId = altId;
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

    public Component getAlternateComponent() {
        return alternateComponent;
    }

    public void setAlternateComponent(Component alternateComponent) {
        this.alternateComponent = alternateComponent;
    }

    public float getDeltaPrice() {
        return deltaPrice;
    }

    public void setDeltaPrice(float deltaPrice) {
        this.deltaPrice = deltaPrice;
    }

}
