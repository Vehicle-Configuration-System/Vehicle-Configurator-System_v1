package com.example.demo.dto;


import jakarta.validation.*;
import jakarta.validation.constraints.Email;
import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.Pattern;
import jakarta.validation.constraints.Size;


public class RegisterRequestDTO {

    @NotBlank(message = "Company Name is required")
    private String companyName;

    @NotBlank(message = "Company Address is required")
    private String companyAddress;

    @NotBlank(message = "Username is required")
    @Size(min = 4, max = 20, message = "Username should be between 4 and 20 characters")
    private String username;

    @NotBlank(message = "Email is required")
    @Email(message = "Invalid Email")
    private String email;

    @NotBlank(message = "Mobile Number is required")
    @Pattern(regexp = "^[6-9]\\d{9}$",
            message = "Mobile Number must contain 10 digits")
    private String mobile;

    @NotBlank(message = "GST Number is required")
    private String gstNo;

    @NotBlank(message = "Registration Number is required")
    private String registrationNo;

    @NotBlank(message = "ST Number is required")
    private String stNo;

    @NotBlank(message = "VAT Number is required")
    private String vatNo;

    @NotBlank(message = "Tax Number is required")
    private String taxNo;

    @NotBlank(message = "Designation is required")
    private String designation;

    @NotBlank(message = "Password is required")
    @Size(min = 8, message = "Password should contain minimum 8 characters")
    private String password;

    @NotBlank(message = "Confirm Password is required")
    private String confirmPassword;

    public RegisterRequestDTO() {
    }

    public RegisterRequestDTO(String companyName, String companyAddress,
            String username, String email, String mobile,
            String gstNo, String registrationNo,
            String stNo, String vatNo,
            String taxNo, String designation,
            String password, String confirmPassword) {

        this.companyName = companyName;
        this.companyAddress = companyAddress;
        this.username = username;
        this.email = email;
        this.mobile = mobile;
        this.gstNo = gstNo;
        this.registrationNo = registrationNo;
        this.stNo = stNo;
        this.vatNo = vatNo;
        this.taxNo = taxNo;
        this.designation = designation;
        this.password = password;
        this.confirmPassword = confirmPassword;
    }

    public String getCompanyName() {
        return companyName;
    }

    public void setCompanyName(String companyName) {
        this.companyName = companyName;
    }

    public String getCompanyAddress() {
        return companyAddress;
    }

    public void setCompanyAddress(String companyAddress) {
        this.companyAddress = companyAddress;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getMobile() {
        return mobile;
    }

    public void setMobile(String mobile) {
        this.mobile = mobile;
    }

    public String getGstNo() {
        return gstNo;
    }

    public void setGstNo(String gstNo) {
        this.gstNo = gstNo;
    }

    public String getRegistrationNo() {
        return registrationNo;
    }

    public void setRegistrationNo(String registrationNo) {
        this.registrationNo = registrationNo;
    }

    public String getStNo() {
        return stNo;
    }

    public void setStNo(String stNo) {
        this.stNo = stNo;
    }

    public String getVatNo() {
        return vatNo;
    }

    public void setVatNo(String vatNo) {
        this.vatNo = vatNo;
    }

    public String getTaxNo() {
        return taxNo;
    }

    public void setTaxNo(String taxNo) {
        this.taxNo = taxNo;
    }

    public String getDesignation() {
        return designation;
    }

    public void setDesignation(String designation) {
        this.designation = designation;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String getConfirmPassword() {
        return confirmPassword;
    }

    public void setConfirmPassword(String confirmPassword) {
        this.confirmPassword = confirmPassword;
    }
}
