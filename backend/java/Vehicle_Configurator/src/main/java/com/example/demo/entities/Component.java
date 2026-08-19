package com.example.demo.entities;

import jakarta.persistence.*;

@Entity
@Table(name = "component")
public class Component {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "comp_id")
    private int compId;

    @Column(name = "comp_name", nullable = false)
    private String compName;

    public Component() {
    }

    public Component(int compId, String compName) {
        this.compId = compId;
        this.compName = compName;
    }

    public int getCompId() {
        return compId;
    }

    public void setCompId(int compId) {
        this.compId = compId;
    }

    public String getCompName() {
        return compName;
    }

    public void setCompName(String compName) {
        this.compName = compName;
    }

}