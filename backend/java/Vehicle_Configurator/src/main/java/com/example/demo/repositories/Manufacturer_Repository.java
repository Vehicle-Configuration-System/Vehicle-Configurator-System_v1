package com.example.demo.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import com.example.demo.entities.Manufacturer;

public interface Manufacturer_Repository
        extends JpaRepository<Manufacturer, Integer> {
}