package com.example.demo.controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.multipart.MultipartFile;

import com.example.demo.services.ExcelUploadService;

@RestController
@RequestMapping("/api/excel")
@CrossOrigin(origins = "http://localhost:5173")
public class ExcelUploadController {

    @Autowired
    private ExcelUploadService excelUploadService;

    @PostMapping("/vehicle-model")
    public ResponseEntity<String> uploadExcel(
            @RequestParam("file") MultipartFile file){

        try{

            excelUploadService.saveVehicleModels(file);

            return ResponseEntity.ok("Excel Uploaded Successfully");

        }
        catch(Exception e){

            return ResponseEntity.badRequest()
                    .body(e.getMessage());

        }

    }

}