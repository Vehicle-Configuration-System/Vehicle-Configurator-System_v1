package com.example.demo.services;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.demo.dto.ManufacturerDTO;
import com.example.demo.repositories.ManufacturerRepository;

@Service
public class ManufacturerService {

    @Autowired
    private ManufacturerRepository manufacturerRepository;

    public List<ManufacturerDTO> getManufacturersBySegment(int segmentId) {

        List<ManufacturerDTO> manufacturerList =
                manufacturerRepository.getManufacturersBySegment(segmentId);

        return manufacturerList;
    }

}