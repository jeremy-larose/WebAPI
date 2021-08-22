# WebAPI
Web API for Clients Database, utilizes Docker, ClarityEmailLibrary, and Swagger

Starting the docker container for MongoDB Database connectivity:

docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=Pass#word1 --network=net5api mongo

Attached to ClarityEmailerLibrary for Clarity Ventures API application.
Usage:
Currently set up to run on localhost, testing with Papercut: 

GET /emails : returns all emails currently in database

GET /emails/send/all : Sends all emails currently existing in database.

GET /emails/send/{id} : Sends existing email {id}.

POST /emails/send/new/{id} : Posts a new email to existing emails to be sent. 
