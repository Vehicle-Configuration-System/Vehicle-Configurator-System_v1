package com.example.demo.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import com.example.demo.dto.ManufacturerDTO;
import com.example.demo.entities.SegMfg;

@Repository
public interface SegMfgRepository extends JpaRepository<SegMfg, Integer> {

    @Query("""
        SELECT new com.example.demo.dto.ManufacturerDTO(
            m.manufacturerId,
            m.manufacturerName
        )
        FROM SegMfg sm
        JOIN sm.manufacturer m
        WHERE sm.segment.segmentId = :segmentId
    """)
    List<ManufacturerDTO> getManufacturersBySegment(int segmentId);

}