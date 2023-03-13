FROM ubuntu:latest
RUN apt update -y && apt upgrade -y && apt install -y wget jq
COPY ./entrypoint.sh ./entrypoint.sh
RUN chmod +x ./entrypoint.sh
ENTRYPOINT [ "./entrypoint.sh" ]
