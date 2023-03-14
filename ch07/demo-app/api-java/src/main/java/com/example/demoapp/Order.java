package com.example.demoapp;

import java.time.LocalDate;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "orders")
class Order {
  @Id 
  @GeneratedValue 
  private Long id;
  @Column(name = "order_date", nullable = false)
  private LocalDate orderDate;
  @Column(name = "status", nullable = false)
  private OrderStatus status;

  Order() {}

  public Order(LocalDate orderDate, OrderStatus status) {
    this.orderDate = orderDate;
    this.status = status;
  }

  public Long getId() {
    return this.id;
  }

  public LocalDate getOrderDate() {
    return this.orderDate;
  }

  public OrderStatus getStatus() {
    return this.status;
  }

  public void setId(Long id) {
    this.id = id;
  }

  public void setOrderDate(LocalDate orderDate) {
    this.orderDate = orderDate;
  }

  public void setStatus(OrderStatus status) {
    this.status = status;
  }

  @Override
  public String toString() {
    return "Order{" + "id=" + this.id + ", orderDate='" + this.orderDate + '\'' + ", status='" + this.status + '\'' + '}';
  }
}