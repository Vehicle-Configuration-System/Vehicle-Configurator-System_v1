package com.example.demo.security;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.web.SecurityFilterChain;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.security.web.authentication.UsernamePasswordAuthenticationFilter;
import org.springframework.web.cors.CorsConfiguration;
import org.springframework.web.cors.CorsConfigurationSource;
import org.springframework.web.cors.UrlBasedCorsConfigurationSource;

 
@Configuration
public class SecurityConfig {


    @Autowired
    private OAuth2SuccessHandler oauth2SuccessHandler;


    @Autowired
    private JwtAuthenticationFilter jwtAuthenticationFilter;



    @Bean
    public SecurityFilterChain securityFilterChain(HttpSecurity http) throws Exception {


        http
            .csrf(csrf -> csrf.disable())


            .cors(cors -> cors.configurationSource(corsConfigurationSource()))


            .authorizeHttpRequests(auth -> auth

                // Normal Login/Register
                .requestMatchers(
                        "/user/login",
                        "/user/register"
                ).permitAll()


                // Google OAuth URLs
                .requestMatchers(
                        "/oauth2/**",
                        "/login/**"
                ).permitAll()

                
                // Remaining APIs protected
//                .anyRequest().authenticated()
                .anyRequest().permitAll()
            )


            // JWT Filter
            .addFilterBefore(
                    jwtAuthenticationFilter,
                    UsernamePasswordAuthenticationFilter.class
            )


            // Google Login
            .oauth2Login(oauth -> oauth
                    .successHandler(oauth2SuccessHandler)
            );


        return http.build();
    }



    @Bean
    public PasswordEncoder passwordEncoder(){

        return new BCryptPasswordEncoder();

    }



    @Bean
    public CorsConfigurationSource corsConfigurationSource(){


        CorsConfiguration configuration =
                new CorsConfiguration();


        configuration.addAllowedOrigin(
                "http://localhost:5173"
        );


        configuration.addAllowedHeader("*");

        configuration.addAllowedMethod("*");

        configuration.setAllowCredentials(true);



        UrlBasedCorsConfigurationSource source =
                new UrlBasedCorsConfigurationSource();


        source.registerCorsConfiguration(
                "/**",
                configuration
        );


        return source;

    }

}