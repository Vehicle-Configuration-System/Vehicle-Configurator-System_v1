package com.example.demo.dto;

public class LoginResponseDTO {

    private String token;
    private int userId;
    private String username;

    public LoginResponseDTO() {
    }

    public LoginResponseDTO(String token, int userId, String username) {
        this.token = token;
        this.userId = userId;
        this.username = username;
    }

    public String getToken() {
        return token;
    }

    public void setToken(String token) {
        this.token = token;
    }

    public int getUserId() {
        return userId;
    }

    public void setUserId(int userId) {
        this.userId = userId;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }
}