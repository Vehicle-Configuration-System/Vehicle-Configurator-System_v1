package com.example.demo.entities;

import jakarta.persistence.*;

@Entity
@Table(name = "user_master")
public class User {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int userId;

    private String companyName;

    @Column(unique = true)
    private String username;

    private String password;

    private String email;
    
    private String role;

    // Getters and Setters
}