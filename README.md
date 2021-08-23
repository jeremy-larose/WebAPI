# WebAPI
Web API for Clients Database, utilizes Docker, ClarityEmailLibrary, and Swagger
Attached to ClarityEmailerLibrary for Clarity Ventures API application.

Starting the docker container for MongoDB Database connectivity:
```
----------------------------------------------------------------------------------------------------------------------------
docker network create claritynetv1
docker run -it --rm -p 8080:80 -e MongoDbSettings:Host=mongo -e MongoDbSettings:Password=Pass#word1 --network=claritynetv1 jeremylarose/webapi:v2
----------------------------------------------------------------------------------------------------------------------------
```
Starts the docker container on port 8080. Then start Papercut on port 35 for testing purposes.

Usage:
Currently set up to run on localhost, testing with Papercut/Postman: 
```
GET /clients : returns all clients currently in database.
GET /emails : returns all emails currently in database.

POST /clients : Inserts a new client into the database.
{
  "name": "string",
  "email": "string"
}
POST /emails: Inserts a new email into the database.
{
  "fromDisplayName": "string",
  "toDisplayName": "string",
  "fromAddress": "string",
  "toAddress": "string",
  "subject": "string",
  "body": "string"
}

GET /emails/send/all : Sends all emails currently existing in database.
GET /emails/send/{id} : Sends existing email at {id}.
POST /emails/send/new/{id} : Posts a new single email to be sent. 
{
  "fromDisplayName": "string",
  "toDisplayName": "string",
  "fromAddress": "string",
  "toAddress": "string",
  "subject": "string",
  "body": "string"
}
```
