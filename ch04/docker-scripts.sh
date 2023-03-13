docker network create my-network

docker container run \
   -e POSTGRES_PASSWORD=Top-Secret \
   --detach \
   --name my-postgres \
   --network my-network \
   postgres:latest 

docker container run \
   --network my-network \
   --rm \
   -e PGPASSWORD=Top-Secret \
   -it \
   postgres:latest psql -h my-postgres -U postgres 

docker container run \
    --name my-mongo \
    --network my-network \
    --detach \
    mongo:latest 