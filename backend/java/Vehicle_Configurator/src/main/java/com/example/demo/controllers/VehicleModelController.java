package com.example.demo.controllers;



import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import com.example.demo.dto.VehicleModelDTO;
import com.example.demo.services.VehicleModelService;
@RestController
@RequestMapping("/model")
public class VehicleModelController {

    @Autowired
    private VehicleModelService vehicleModelService;

    @GetMapping("/manufacturer/{manufacturerId}/segment/{segmentId}")
    public ResponseEntity<List<VehicleModelDTO>> getModelsByManufacturerAndSegment(
            @PathVariable int manufacturerId,
            @PathVariable int segmentId) {

        List<VehicleModelDTO> modelList =
                vehicleModelService.getModelsByManufacturerAndSegment(
                        manufacturerId,
                        segmentId);

        return new ResponseEntity<>(modelList, HttpStatus.OK);
    }
}