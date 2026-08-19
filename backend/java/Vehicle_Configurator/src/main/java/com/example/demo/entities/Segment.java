package com.example.demo.entities;

import jakarta.persistence.*;

@Entity
@Table(name = "segment_master")
public class Segment {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "segment_id")
    private int segmentId;

    @Column(name = "segment_name")
    private String segmentName;

    public Segment() {
    }

    public Segment(int segmentId, String segmentName) {
        this.segmentId = segmentId;
        this.segmentName = segmentName;
    }

    public int getSegmentId() {
        return segmentId;
    }

    public void setSegmentId(int segmentId) {
        this.segmentId = segmentId;
    }

    public String getSegmentName() {
        return segmentName;
    }

    public void setSegmentName(String segmentName) {
        this.segmentName = segmentName;
    }
}