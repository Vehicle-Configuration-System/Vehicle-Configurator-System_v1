package com.example.demo.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import com.example.demo.dto.VehicleModelDTO;
import com.example.demo.entities.VehicleModel;

public interface VehicleModelRepository extends JpaRepository<VehicleModel, Integer> {

	@Query("SELECT new com.example.demo.dto.VehicleModelDTO(" +
		       "v.modelId, v.modelName, v.minimumQuantity) " +
		       "FROM VehicleModel v " +
		       "WHERE v.manufacturer.manufacturerId = :manufacturerId " +
		       "AND v.segment.segmentId = :segmentId")
		List<VehicleModelDTO> getModelsByManufacturerAndSegment(
		        @Param("manufacturerId") int manufacturerId,
		        @Param("segmentId") int segmentId);
}
