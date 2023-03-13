package com.example.demoapp;

import java.time.LocalDate;
import org.springframework.boot.CommandLineRunner;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
class LoadDatabase {
  @Bean
  CommandLineRunner initDatabase(OrderRepository repository) {

    return args -> {
      repository.save(new Order(LocalDate.parse("2021-01-10"), OrderStatus.FULFILLED));
      repository.save(new Order(LocalDate.parse("2021-01-11"), OrderStatus.FULFILLED));
      repository.save(new Order(LocalDate.parse("2021-02-12"), OrderStatus.DRAFT));
      repository.save(new Order(LocalDate.parse("2021-02-12"), OrderStatus.APPROVED));
      repository.save(new Order(LocalDate.parse("2021-03-13"), OrderStatus.DRAFT));
      repository.save(new Order(LocalDate.parse("2021-03-13"), OrderStatus.DRAFT));
    };
  }
}
