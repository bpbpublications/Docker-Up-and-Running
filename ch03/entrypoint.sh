#!/bin/bash

# exit on CTRL-c
trap 'exit -1' SIGINT

while : 
do
    wget -qO- http://jservice.io/api/random | jq .[0].question;
    sleep 5;
done
