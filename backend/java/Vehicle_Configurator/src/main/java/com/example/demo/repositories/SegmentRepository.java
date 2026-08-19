package com.example.demo.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.example.demo.entities.Segment;

@Repository
public interface SegmentRepository extends JpaRepository<Segment, Integer> {

}
