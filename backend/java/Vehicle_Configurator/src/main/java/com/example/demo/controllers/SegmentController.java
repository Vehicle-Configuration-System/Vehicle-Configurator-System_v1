package com.example.demo.controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import com.example.demo.entities.Segment;
import com.example.demo.services.SegmentService;
import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/segment")
@CrossOrigin(origins = "http://localhost:5173")
public class SegmentController {

    @Autowired
    private SegmentService segmentService;

    // Get All Segments
    @GetMapping
    public ResponseEntity<List<Segment>> getAllSegments() {

        List<Segment> segmentList = segmentService.getAllSegments();

        return new ResponseEntity<>(segmentList, HttpStatus.OK);
    }

    // Get Segment By Id
    @GetMapping("/{id}")
    public ResponseEntity<Segment> getSegmentById(@PathVariable int id) {

        Optional<Segment> optionalSegment = segmentService.getSegmentById(id);

        if (optionalSegment.isPresent()) {
            return new ResponseEntity<>(optionalSegment.get(), HttpStatus.OK);
        }

        return new ResponseEntity<>(HttpStatus.NOT_FOUND);
    }

    // Add Segment
    @PostMapping
    public ResponseEntity<Segment> addSegment(@RequestBody Segment segment) {

        Segment savedSegment = segmentService.addSegment(segment);

        return new ResponseEntity<>(savedSegment, HttpStatus.CREATED);
    }

    // Update Segment
    @PutMapping("/{id}")
    public ResponseEntity<Segment> updateSegment(@PathVariable int id,
                                                 @RequestBody Segment segment) {

        Optional<Segment> updatedSegment = segmentService.updateSegment(id, segment);

        if (updatedSegment.isPresent()) {
            return new ResponseEntity<>(updatedSegment.get(), HttpStatus.OK);
        }

        return new ResponseEntity<>(HttpStatus.NOT_FOUND);
    }

    // Delete Segment
    @DeleteMapping("/{id}")
    public ResponseEntity<String> deleteSegment(@PathVariable int id) {

        boolean isDeleted = segmentService.deleteSegment(id);

        if (isDeleted) {
            return new ResponseEntity<>("Segment Deleted Successfully", HttpStatus.OK);
        }

        return new ResponseEntity<>("Segment Not Found", HttpStatus.NOT_FOUND);
    }
}
