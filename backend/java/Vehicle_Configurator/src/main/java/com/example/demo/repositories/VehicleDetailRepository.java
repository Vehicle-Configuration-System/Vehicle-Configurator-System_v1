package com.example.demo.repositories;



import org.springframework.data.jpa.repository.JpaRepository;
import com.example.demo.entities.VehicleDetail;

import java.util.List;

public interface VehicleDetailRepository 
        extends JpaRepository<VehicleDetail, Integer>{

    List<VehicleDetail> findByModel_ModelId(int modelId);

}