package com.example.demo.services;

import java.io.InputStream;

import org.apache.poi.ss.usermodel.*;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.web.multipart.MultipartFile;

import com.example.demo.entities.VehicleModel;
import com.example.demo.entities.Manufacturer;
import com.example.demo.entities.Segment;
import com.example.demo.repositories.VehicleModelRepository;
import com.example.demo.repositories.ManufacturerRepository;
import com.example.demo.repositories.Manufacturer_Repository;
import com.example.demo.repositories.SegmentRepository;

@Service
public class ExcelUploadService {

    @Autowired
    private VehicleModelRepository vehicleModelRepository;

    @Autowired
    private Manufacturer_Repository manufacturerRepository;

    @Autowired
    private SegmentRepository segmentRepository;

    public void saveVehicleModels(MultipartFile file)
            throws Exception {

        InputStream inputStream =
                file.getInputStream();

        Workbook workbook =
                WorkbookFactory.create(inputStream);

        Sheet sheet =
                workbook.getSheetAt(0);

        boolean firstRow = true;

        for(Row row : sheet){

            if(firstRow){

                firstRow = false;

                continue;

            }

            VehicleModel model =
                    new VehicleModel();

            model.setModelName(
                    row.getCell(0)
                    .getStringCellValue()
            );

            model.setBasePrice(
                    (int)row.getCell(1)
                    .getNumericCellValue()
            );

            model.setImage(
                    row.getCell(2)
                    .getStringCellValue()
            );

            model.setMinimumQuantity(
                    (int)row.getCell(3)
                    .getNumericCellValue()
            );

            int manufacturerId =
                    (int)row.getCell(4)
                    .getNumericCellValue();

            int segmentId =
                    (int)row.getCell(5)
                    .getNumericCellValue();

            Manufacturer manufacturer =
                    manufacturerRepository
                    .findById(manufacturerId)
                    .orElseThrow();

            Segment segment =
                    segmentRepository
                    .findById(segmentId)
                    .orElseThrow();

            model.setManufacturer(manufacturer);

            model.setSegment(segment);

            vehicleModelRepository.save(model);

        }

        workbook.close();

    }

}