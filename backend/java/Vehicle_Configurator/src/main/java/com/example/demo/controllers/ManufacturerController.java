package com.example.demo.controllers;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import com.example.demo.dto.ManufacturerDTO;
import com.example.demo.services.ManufacturerService;

@RestController
@RequestMapping("/manufacturer")
@CrossOrigin(origins = "http://localhost:5173")
public class ManufacturerController {

    @Autowired
    private ManufacturerService manufacturerService;

    // Test API
    @GetMapping("/test")
    public String test() {
        return "Manufacturer Controller Working";
    }

    // Get Manufacturers By Segment
    @GetMapping("/segment/{segmentId}")
    public ResponseEntity<List<ManufacturerDTO>> getManufacturersBySegment(
            @PathVariable int segmentId) {

        List<ManufacturerDTO> manufacturerList =
                manufacturerService.getManufacturersBySegment(segmentId);

        return new ResponseEntity<>(manufacturerList, HttpStatus.OK);
    }
}