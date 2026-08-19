package com.example.demo.controllers;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;


import com.example.demo.dto.DefaultConfigurationDTO;
import com.example.demo.services.VehicleDetailService;



@RestController
@RequestMapping("/api/default-config")
@CrossOrigin("*")
public class VehicleDetailController {



    private VehicleDetailService service;



    public VehicleDetailController(
            VehicleDetailService service){

        this.service = service;

    }




    @GetMapping("/{modelId}")
    public ResponseEntity<?> getDefaultConfiguration(
            @PathVariable int modelId){



        DefaultConfigurationDTO response =
                service.getDefaultConfiguration(modelId);



        if(response==null){

            return ResponseEntity
                    .notFound()
                    .build();

        }



        return ResponseEntity.ok(response);

    }


}