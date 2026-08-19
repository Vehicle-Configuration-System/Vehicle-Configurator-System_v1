package com.example.demo.security;

import java.io.IOException;
import java.net.URLEncoder;
import java.nio.charset.StandardCharsets;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.Authentication;
import org.springframework.security.oauth2.client.authentication.OAuth2AuthenticationToken;
import org.springframework.security.oauth2.core.user.OAuth2User;
import org.springframework.security.web.authentication.AuthenticationSuccessHandler;
import org.springframework.stereotype.Component;

import com.example.demo.entities.User;
import com.example.demo.repositories.UserRepository;

import jakarta.servlet.ServletException;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

@Component
public class OAuth2SuccessHandler implements AuthenticationSuccessHandler {


    @Autowired
    private JwtUtil jwtUtil;


    @Autowired
    private UserRepository userRepository;


    @Override
    public void onAuthenticationSuccess(
            HttpServletRequest request,
            HttpServletResponse response,
            Authentication authentication
    ) throws IOException, ServletException {


        System.out.println("===== GOOGLE SUCCESS HANDLER CALLED =====");


        OAuth2AuthenticationToken oauthToken =
                (OAuth2AuthenticationToken) authentication;


        OAuth2User oauthUser =
                oauthToken.getPrincipal();


        String email = oauthUser.getAttribute("email");


        System.out.println("Google Email : " + email);



        User user = userRepository.findByEmail(email)
                .orElseThrow(() ->
                    new RuntimeException(
                        "Google user not found : " + email
                    )
                );



        String token = jwtUtil.generateToken(
                user.getUsername(),
                user.getUserId()
        );


        System.out.println("JWT Generated : " + token);

        System.out.println(user.getUsername());;
        String redirectUrl =
                "http://localhost:5173/oauth-success"
                + "?token=" + token
                + "&userId=" + user.getUserId()
                + "&username="  + URLEncoder.encode(
                        user.getUsername(),
                        StandardCharsets.UTF_8);


        System.out.println("Redirect URL : " + redirectUrl);


        response.sendRedirect(redirectUrl);

    }
}