package com.example.demo.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;

import com.example.demo.entities.AlternateComponent;

public interface AlternateComponentRepository
extends JpaRepository<AlternateComponent, Integer> {

List<AlternateComponent> findByModel_ModelIdAndComponent_CompId(
    int modelId,
    int componentId);

AlternateComponent findByAlternateComponent_CompIdAndComponent_CompIdAndModel_ModelId(
        int altCompId,
        int compId,
        int modelId);
}
