Steps to build and deploy
============================

1) Create azure sql table and specify the connection string in docker-compose.yml file

2) Build the docker image using docker-compose up -d

3) Push the docker image to azure container repository

4) Deploy the image in the AKS cluster by specifying demoapideploy.yml file


TODO : Use any ORM for object(POCO) mapping, currently fetched only employee names.

Integrate with KeyVault and just configure secret name while deploying.
