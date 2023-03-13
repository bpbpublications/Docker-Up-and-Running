set -e

psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname "$POSTGRES_DB" <<-EOSQL
    CREATE USER demo-user;
    CREATE DATABASE demo-database;
    GRANT ALL PRIVILEGES ON DATABASE demo-database TO demo-user;
EOSQL