package com.example.logdemo;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.context.metrics.buffering.BufferingApplicationStartup;

@SpringBootApplication
public class LogDemoApplication {

	public static void main(String[] args) {
		// SpringApplication.run(LogDemoApplication.class, args);
		SpringApplication app = new SpringApplication(LogDemoApplication.class);
        app.setApplicationStartup(new BufferingApplicationStartup(1000));
        app.run(args);
	}

}
