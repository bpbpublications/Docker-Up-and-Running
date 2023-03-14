FROM openjdk:8
WORKDIR /app
ENV JAVA_TOOL_OPTIONS -agentlib:jdwp=transport=dt_socket,address=8000,server=y,suspend=n
COPY target/debug-java-1.0-SNAPSHOT.jar  debug-java.jar
ENTRYPOINT ["java", "-cp", "debug-java.jar", "com.example.App"]