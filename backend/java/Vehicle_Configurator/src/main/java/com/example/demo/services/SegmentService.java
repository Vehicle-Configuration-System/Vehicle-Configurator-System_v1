package com.example.demo.services;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import com.example.demo.entities.*;
import com.example.demo.repositories.*;
@Service
public class SegmentService {

    @Autowired
    private SegmentRepository segmentRepository;

    // Get All Segments
    public List<Segment> getAllSegments() {
        return segmentRepository.findAll();
    }

    // Get Segment By Id
    public Optional<Segment> getSegmentById(int id) {
        return segmentRepository.findById(id);
    }

    // Add Segment
    public Segment addSegment(Segment segment) {
        return segmentRepository.save(segment);
    }

    // Update Segment
    public Optional<Segment> updateSegment(int id, Segment segment) {

        Optional<Segment> optionalSegment = segmentRepository.findById(id);

        if (optionalSegment.isPresent()) {

            Segment existingSegment = optionalSegment.get();

            existingSegment.setSegmentName(segment.getSegmentName());

            Segment updatedSegment = segmentRepository.save(existingSegment);

            return Optional.of(updatedSegment);
        }

        return Optional.empty();
    }

    // Delete Segment
    public boolean deleteSegment(int id) {

        Optional<Segment> optionalSegment = segmentRepository.findById(id);

        if (optionalSegment.isPresent()) {
            segmentRepository.deleteById(id);
            return true;
        }

        return false;
    }
}