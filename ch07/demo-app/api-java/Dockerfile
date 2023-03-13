FROM maven as builder
WORKDIR /app
COPY pom.xml ./
COPY src ./src
RUN mvn clean package -DskipTests

FROM openjdk:jre-slim
WORKDIR /app
COPY --from=builder /app/target/*.jar ./application.jar
ENTRYPOINT ["java", "-jar", "application.jar"]
 