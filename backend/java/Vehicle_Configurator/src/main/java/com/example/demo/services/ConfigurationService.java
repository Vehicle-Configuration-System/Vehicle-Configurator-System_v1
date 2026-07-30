package com.example.demo.services;

import java.util.ArrayList;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.demo.dto.AlternateComponentDTO;
import com.example.demo.dto.ConfigurationResponseDTO;
import com.example.demo.entities.AlternateComponent;
import com.example.demo.entities.VehicleDetail;
import com.example.demo.repositories.AlternateComponentRepository;
import com.example.demo.repositories.VehicleDetailRepository;

@Service
public class ConfigurationService {

    @Autowired
    private VehicleDetailRepository vehicleDetailRepository;
    @Autowired
    private AlternateComponentRepository alternateComponentRepository;

    public List<ConfigurationResponseDTO> getConfiguration(int modelId){

        List<VehicleDetail> vehicleDetails =
                vehicleDetailRepository.findByModel_ModelId(modelId);

        List<ConfigurationResponseDTO> response =
                new ArrayList<>();

        for(VehicleDetail detail : vehicleDetails){

            ConfigurationResponseDTO dto =
                    new ConfigurationResponseDTO();

            dto.setComponentId(
                    detail.getComponent().getCompId());

            dto.setComponentName(
                    detail.getComponent().getCompName());

            dto.setComponentType(
                    detail.getCompType());

            dto.setConfigurable(
                    detail.getIsConfigurable());

            response.add(dto);
        }

        return response;
    }

    public List<AlternateComponentDTO> getAlternateComponents(
            int modelId,
            int componentId) {

        List<AlternateComponent> list =
                alternateComponentRepository
                .findByModel_ModelIdAndComponent_CompId(
                        modelId,
                        componentId);

        List<AlternateComponentDTO> response =
                new ArrayList<>();

        for (AlternateComponent alt : list) {

            AlternateComponentDTO dto =
                    new AlternateComponentDTO();

            dto.setAltId(alt.getAltId());

            dto.setComponentId(
                    alt.getAlternateComponent().getCompId());

            dto.setComponentName(
                    alt.getAlternateComponent().getCompName());

            dto.setDeltaPrice(
                    alt.getDeltaPrice());

            response.add(dto);
        }

        return response;
    }
}
