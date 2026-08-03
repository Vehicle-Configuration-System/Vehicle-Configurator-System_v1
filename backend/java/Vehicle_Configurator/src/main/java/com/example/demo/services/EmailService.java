package com.example.demo.services;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.core.io.ByteArrayResource;
import org.springframework.mail.javamail.JavaMailSender;
import org.springframework.mail.javamail.MimeMessageHelper;
import org.springframework.stereotype.Service;
import org.springframework.web.multipart.MultipartFile;

import jakarta.mail.internet.MimeMessage;

@Service
public class EmailService {

    @Autowired
    private JavaMailSender mailSender;

    public void sendInvoice(String email,
                            MultipartFile pdf) {

        try {

            MimeMessage message =
                    mailSender.createMimeMessage();

            MimeMessageHelper helper =
                    new MimeMessageHelper(message, true);

            helper.setFrom("vehicleconfigurator220@gmail.com");

            helper.setTo(email);

            helper.setSubject("Vehicle Configuration Invoice");

            helper.setText(
                    "Dear Customer,\n\n" +
                    "Please find attached your Vehicle Configuration Invoice.\n\n" +
                    "Thank You."
            );

            helper.addAttachment(
                    "Invoice.pdf",
                    new ByteArrayResource(pdf.getBytes())
            );

            mailSender.send(message);

        } catch (Exception e) {

            throw new RuntimeException(e);

        }

    }

}