package com.example.playground;

import org.springframework.stereotype.Component;
import org.springframework.beans.factory.annotation.Value;

@Component
public class MyBean {

    @Value("${name}")
    private String name;

    // ...

    public String getName(){
        return this.name;
    }

}