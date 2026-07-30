package com.example.demo.services;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.demo.dto.ManufacturerDTO;
import com.example.demo.repositories.SegMfgRepository;

@Service
public class SegMfgService {

    @Autowired
    private SegMfgRepository segMfgRepository;

    public List<ManufacturerDTO> getManufacturersBySegment(int segmentId) {

        return segMfgRepository.getManufacturersBySegment(segmentId);

    }

}
