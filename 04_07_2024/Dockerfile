FROM postgres

ENV POSTGRES_DB=myCustomDB
ENV POSTGRES_USER=customuser
ENV POSTGRES_PASSWORD=custompassword

COPY init.sql /docker-entrypoint-initdb.d/

COPY select.sh /docker-entrypoint-initdb.d/
RUN chmod +x /docker-entrypoint-initdb.d/select.sh
