package com.example.demo.services;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.*;

import java.util.Arrays;
import java.util.List;
import java.util.Optional;

import com.example.demo.entities.Segment;
import com.example.demo.repositories.SegmentRepository;

import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;

@ExtendWith(MockitoExtension.class)
class SegmentServiceTest {

    @Mock
    private SegmentRepository segmentRepository;

    @InjectMocks
    private SegmentService segmentService;

    @Test
    void testGetAllSegments() {

        Segment s1 = new Segment();
        s1.setSegmentId(1);
        s1.setSegmentName("SUV");

        Segment s2 = new Segment();
        s2.setSegmentId(2);
        s2.setSegmentName("Sedan");

        when(segmentRepository.findAll())
                .thenReturn(Arrays.asList(s1, s2));

        List<Segment> result = segmentService.getAllSegments();

        assertEquals(2, result.size());
        assertEquals("SUV", result.get(0).getSegmentName());

        verify(segmentRepository, times(1)).findAll();
    }

    @Test
    void testGetSegmentById() {

        Segment segment = new Segment();
        segment.setSegmentId(1);
        segment.setSegmentName("SUV");

        when(segmentRepository.findById(1))
                .thenReturn(Optional.of(segment));

        Optional<Segment> result = segmentService.getSegmentById(1);

        assertTrue(result.isPresent());
        assertEquals("SUV", result.get().getSegmentName());

        verify(segmentRepository).findById(1);
    }

    @Test
    void testAddSegment() {

        Segment segment = new Segment();
        segment.setSegmentId(1);
        segment.setSegmentName("SUV");

        when(segmentRepository.save(segment))
                .thenReturn(segment);

        Segment saved = segmentService.addSegment(segment);

        assertNotNull(saved);
        assertEquals("SUV", saved.getSegmentName());

        verify(segmentRepository).save(segment);
    }

    @Test
    void testUpdateSegment() {

        Segment existing = new Segment();
        existing.setSegmentId(1);
        existing.setSegmentName("SUV");

        Segment updated = new Segment();
        updated.setSegmentName("Luxury SUV");

        when(segmentRepository.findById(1))
                .thenReturn(Optional.of(existing));

        when(segmentRepository.save(any(Segment.class)))
                .thenReturn(existing);

        Optional<Segment> result =
                segmentService.updateSegment(1, updated);

        assertTrue(result.isPresent());
        assertEquals("Luxury SUV",
                result.get().getSegmentName());

        verify(segmentRepository).findById(1);
        verify(segmentRepository).save(existing);
    }

    @Test
    void testDeleteSegment() {

        Segment segment = new Segment();
        segment.setSegmentId(1);
        segment.setSegmentName("SUV");

        when(segmentRepository.findById(1))
                .thenReturn(Optional.of(segment));

        boolean deleted = segmentService.deleteSegment(1);

        assertTrue(deleted);

        verify(segmentRepository).deleteById(1);
    }

    @Test
    void testDeleteSegmentNotFound() {

        when(segmentRepository.findById(100))
                .thenReturn(Optional.empty());

        boolean deleted = segmentService.deleteSegment(100);

        assertFalse(deleted);

        verify(segmentRepository, never()).deleteById(anyInt());
    }

}