# BookstoreWebApp
This is the BookstoreWebApp project - or should I simply say the web app of the bookstore project.

Will mention this again - to use the docker-compose file found in the api github repository you will first need to download/pull this two docker repositories:
1) Api: docker pull alexisk120/bookapi
2) WebApp: docker pull alexisk120/bookwebapp

Again I will mention that once more - for either case either local use or with the docker-compose file, after running the compose file you will also need to fill in the SQL Server the relative database with its data to properly use the project whith the use of the provided in api project sql script!
1) Sql script location: Database_setup_script in the main direcotry of BookstoreApi project
2) Docker-compose.yml location: Docker_compose_file in the main direcotry of BookstoreApi project

Another note is the base api url - I initilize it by setting up the sdk client in the program file of the web project
![image](https://github.com/Alex120gb/BookstoreWebApp/assets/93439743/793a95c8-6950-49c5-8f9a-5da49b8c1902)

As you can see the base api url is like this: http://bookstoreapi:80 - this is used with the docker-compose. But if you want to run this locally, you will have to change it to the new base URL that your local api will produce (it is different usually for everyone) - this new local url can be produced after setting up and running the api locally. 
Instructions on how to set up the api can be found in this repository https://github.com/Alex120gb/BookstoreApi

But there is another link you can use which is this one: http://localhost:8080 - this only if the api runs in the docker, but for some reason you want to run locally the web project, this way you can use the api link of the api running on the docker server instead!
That is all you really need to know regarding the webb app - to reiterate for local use (depending on use case): first deploy and run the api to see what the new local URL will be, and secondly copy that URL and paste it in the mentioned location mentioned above (in Program.cs).

And again, in either case please dont forget to create the tables with the proivded sql script in the api github repository!
