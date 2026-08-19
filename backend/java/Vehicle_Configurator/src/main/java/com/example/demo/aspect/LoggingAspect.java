package com.example.demo.aspect;

import org.aspectj.lang.JoinPoint;
import org.aspectj.lang.annotation.AfterReturning;
import org.aspectj.lang.annotation.AfterThrowing;
import org.aspectj.lang.annotation.Aspect;
import org.aspectj.lang.annotation.Before;
import org.springframework.stereotype.Component;

@Aspect
@Component
public class LoggingAspect {

    @Before("execution(* com.example.demo.services.UserService.login(..))")
    public void beforeLogin(JoinPoint joinPoint) {

        System.out.println("========== AOP ==========");
        System.out.println("Login Method Started");
        System.out.println("=========================");

    }

    @AfterReturning("execution(* com.example.demo.services.UserService.login(..))")
    public void afterLogin() {

        System.out.println("========== AOP ==========");
        System.out.println("Login Successful");
        System.out.println("=========================");

    }

    @AfterThrowing("execution(* com.example.demo.services.UserService.login(..))")
    public void loginFailed() {

        System.out.println("========== AOP ==========");
        System.out.println("Login Failed");
        System.out.println("=========================");

    }

}