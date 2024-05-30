# DevFreela

Project with the purpose of managing projects, clients and freelance developers.

The following technologies and/or principles were used:

- Clean architecture
- SOLID
- CQRS
- Dapper
- Entity Framework Core
- RabbitMQ
- MediatR
- Automapper
- FluentValidation
- CORS
- JWT Token
- Authorization
- Authentication

## Dependence

To run this project, you must have an instance of the RabbitMQ service running. The easiest way to create the service is through a docker container.
Windows users can have a [Docker Desktop](https://www.docker.com/products/docker-desktop/) installation (running) and run the following command to 
make the RabbitMQ service available:

`docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3.13-management`

To monitor and even manage DevFreela messages in RabbitMQ, you can use the RabbitMQ manager itself, which is hosted where the docker container is running, 
available at http://localhost:15672/.
Username and password in the basic configuration is `guest`.

