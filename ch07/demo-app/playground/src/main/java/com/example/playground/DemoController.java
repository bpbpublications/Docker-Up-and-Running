
package com.example.playground;

import org.springframework.web.bind.annotation.RestController;

import com.example.playground.MyBean;

import org.springframework.web.bind.annotation.GetMapping;

@RestController
class DemoController {
    private MyBean bean;
     
    public DemoController(MyBean bean){
        this.bean = bean;
    }

    @GetMapping("/demo")
    String home() {
        return "Foo bar: " + bean.getName();
    }
}