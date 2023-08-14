# BookstoreWebApp
This is the BookstoreWebApp project - or should I simply say the web app of the bookstore project.

In here you will also find the docker-compose file which you can use as specified in the api project after downloading the two repositories from docker:
1) Api: docker pull alexisk120/bookapi
2) WebApp: docker pull alexisk120/bookwebapp

Again I will mention that once you run the docker-compose file, you will also need to fill in the SQL Server the relative database with its data to properly use the project!

Another note is the base api url - I initilize it by setting up the sdk client in the program file of the web project
![image](https://github.com/Alex120gb/BookstoreWebApp/assets/93439743/894d4e47-c308-4bad-953f-cd5585329a39)

As you can see the base api url is like this: http://bookstoreapi:80 - this is used with the docker-compose. But if you want to run this locally, you will have to change it to the new base URL that your local api will produce (it is different usually for everyone) - this new local url can be produces after setting up the api. 
Instructions on how to set up the api can be found in this repository https://github.com/Alex120gb/BookstoreApi

That is all you really need to know regarding the webb app - to reiterate for local use: first deploy and run the api to see what the new local URL will be, and secondly copy that URL and paste it in the mentioned location mentioned above (in Program.cs).

