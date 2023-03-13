package com.example.logdemo;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class HelloController {

	Logger logger = LoggerFactory.getLogger(HelloController.class);
	
	@GetMapping("/")
	public String index() {
		logger.trace("Sample TRACE message");
		logger.debug("Sample DEBUG message");
		logger.info("Sample INFO message");
		logger.warn("Sample WARN message");
		logger.error("Sample ERROR message");
		
		return "Greetings from my Spring Boot!";
	}
}