package com.example.demo.services;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;

import com.example.demo.dto.LoginRequestDTO;
import com.example.demo.dto.LoginResponseDTO;
import com.example.demo.dto.RegisterRequestDTO;
import com.example.demo.entities.User;
import com.example.demo.exceptions.InvalidCredentialsException;
import com.example.demo.repositories.UserRepository;
import com.example.demo.security.JwtUtil;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
@Service
public class UserService {

	private static final Logger logger =
	        LoggerFactory.getLogger(UserService.class);
    @Autowired
    private UserRepository userRepository;
    @Autowired
    private JwtUtil jwtUtil;
    @Autowired
    private PasswordEncoder passwordEncoder;

    public String register(RegisterRequestDTO dto) {

        if (userRepository.existsByUsername(dto.getUsername())) {
            return "Username already exists";
        }

        if (userRepository.existsByEmail(dto.getEmail())) {
            return "Email already exists";
        }

        if (userRepository.existsByMobile(dto.getMobile())) {
            return "Mobile Number already exists";
        }

        if (userRepository.existsByGstNo(dto.getGstNo())) {
            return "GST Number already exists";
        }

        if (!dto.getPassword().equals(dto.getConfirmPassword())) {
            return "Password and Confirm Password do not match";
        }

        User user = new User();

        user.setCompanyName(dto.getCompanyName());
        user.setCompanyAddress(dto.getCompanyAddress());
        user.setUsername(dto.getUsername());
        user.setEmail(dto.getEmail());
        user.setMobile(dto.getMobile());
        user.setGstNo(dto.getGstNo());
        user.setRegistrationNo(dto.getRegistrationNo());
        user.setStNo(dto.getStNo());
        user.setVatNo(dto.getVatNo());
        user.setTaxNo(dto.getTaxNo());
        user.setDesignation(dto.getDesignation());

        // Encrypt Password
        user.setPassword(passwordEncoder.encode(dto.getPassword()));

        // Default Role
        user.setRole("ROLE_USER");

        userRepository.save(user);

        return "User Registered Successfully";
    }
    
//    public LoginResponseDTO login(LoginRequestDTO dto) {
//
//        User user = userRepository.findByEmail(dto.getEmail())
//                .orElseThrow(() -> new InvalidCredentialsException("Invalid Email"));
//
//        if (!passwordEncoder.matches(dto.getPassword(), user.getPassword())) {
//            throw new InvalidCredentialsException("Invalid Password");
//        }
//
//        String token = jwtUtil.generateToken(user.getEmail());
//
//        return new LoginResponseDTO(token);
//    }
    public LoginResponseDTO login(LoginRequestDTO dto) {

        logger.info("Login attempt for email: {}", dto.getEmail());

        User user = userRepository.findByEmail(dto.getEmail())
                .orElseThrow(() -> {

                    logger.error("Login failed. Email not found: {}", dto.getEmail());

                    return new InvalidCredentialsException("Invalid Email");
                });

        if (!passwordEncoder.matches(dto.getPassword(), user.getPassword())) {

            logger.error("Login failed. Wrong password for email: {}", dto.getEmail());

            throw new InvalidCredentialsException("Invalid Password");
        }

        String token = jwtUtil.generateToken(
                user.getUsername(),
                user.getUserId());

        logger.info("Login successful for email: {}", dto.getEmail());

        return new LoginResponseDTO(
                token,
                user.getUserId(),
                user.getUsername());
    }
}