package com.example.demo.services;


import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.demo.dto.VehicleModelDTO;
import com.example.demo.repositories.VehicleModelRepository;

@Service
public class VehicleModelService {

    @Autowired
    private VehicleModelRepository vehicleModelRepository;

    public List<VehicleModelDTO> getModelsByManufacturerAndSegment(
            int manufacturerId,
            int segmentId) {

        return vehicleModelRepository.getModelsByManufacturerAndSegment(
                manufacturerId,
                segmentId);
    }
}