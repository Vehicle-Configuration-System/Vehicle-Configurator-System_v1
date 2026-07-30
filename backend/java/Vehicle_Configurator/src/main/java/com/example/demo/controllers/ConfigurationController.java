package com.example.demo.controllers;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.example.demo.dto.AlternateComponentDTO;
import com.example.demo.dto.ConfigurationResponseDTO;
import com.example.demo.services.ConfigurationService;

@RestController
@RequestMapping("/api/configurations")
@CrossOrigin(origins="http://localhost:5173")
public class ConfigurationController {

    @Autowired
    private ConfigurationService configurationService;

    @GetMapping("/{modelId}")
    public ResponseEntity<List<ConfigurationResponseDTO>>
    getConfiguration(
            @PathVariable int modelId){

        return ResponseEntity.ok(
                configurationService.getConfiguration(modelId));

    }
    
    @GetMapping("/{modelId}/components/{componentId}/alternatives")
    public ResponseEntity<List<AlternateComponentDTO>>
    getAlternateComponents(
            @PathVariable int modelId,
            @PathVariable int componentId) {

        return ResponseEntity.ok(
                configurationService.getAlternateComponents(
                        modelId,
                        componentId));
    }

}
