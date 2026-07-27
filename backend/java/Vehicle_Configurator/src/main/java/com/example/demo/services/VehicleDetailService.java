package com.example.demo.services;

import java.util.ArrayList;
import java.util.List;


import org.springframework.stereotype.Service;


import com.example.demo.dto.*;
import com.example.demo.entities.VehicleDetail;
import com.example.demo.repositories.VehicleDetailRepository;



@Service
public class VehicleDetailService {


    private VehicleDetailRepository repository;



    public VehicleDetailService(
            VehicleDetailRepository repository){

        this.repository = repository;

    }



    public DefaultConfigurationDTO getDefaultConfiguration(int modelId){


        List<VehicleDetail> details =
                repository.findByModel_ModelId(modelId);



        if(details.isEmpty()){

            return null;

        }



        VehicleDetail first = details.get(0);



        // Vehicle Details

        VehicleInfoDTO vehicle = new VehicleInfoDTO();


        vehicle.setModelId(
                first.getModel().getModelId()
        );


        vehicle.setModelName(
                first.getModel().getModelName()
        );


        vehicle.setImage(
                first.getModel().getImage()
        );


        vehicle.setBasePrice(
                first.getModel().getBasePrice()
        );


        vehicle.setManufacturer(
                first.getModel()
                .getManufacturer()
                .getManufacturerName()
        );


        vehicle.setSegment(
                first.getModel()
                .getSegment()
                .getSegmentName()
        );



        // Components

        List<ComponentInfoDTO> components =
                new ArrayList<>();



        for(VehicleDetail detail : details){


            ComponentInfoDTO component =
                    new ComponentInfoDTO();


            component.setConfigId(
                    detail.getConfigId()
            );


            component.setComponentName(
                    detail.getComponent()
                    .getCompName()
            );


            component.setComponentType(
                    detail.getCompType()
            );


            component.setConfigurable(
                    detail.getIsConfigurable()
            );


            components.add(component);

        }



        DefaultConfigurationDTO response =
                new DefaultConfigurationDTO();


        response.setVehicle(vehicle);

        response.setComponents(components);



        return response;

    }

}