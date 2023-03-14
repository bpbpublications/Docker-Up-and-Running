docker container run -p 4000:3000 \
    -v $PWD/src:/app/src \
    -v $PWD/public:/app/public \
    hot-reload-react
