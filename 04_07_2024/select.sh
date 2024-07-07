#!/bin/bash

wait_for_postgres() {
    until psql -h "localhost" -U "$POSTGRES_USER" -d "$POSTGRES_DB" -c '\q' &>/dev/null; do
        echo "Postgres is unavailable - sleeping"
        sleep 1
    done
    echo "Postgres is up!"
}


wait_for_postgres

psql -U "$POSTGRES_USER" -d "$POSTGRES_DB" -c \
"SELECT e.Employee_name, e.Age, e.Phone, d.Department_name, s.Salary_amount AS Salary
FROM Employee e
JOIN Department d ON e.Department_id = d.Department_id
JOIN Salary s ON e.Employee_id = s.Employee_id;"
