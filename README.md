# Glossina
Glossina is an application for staying awake a server.

#Why use Glossina?
If you have deployed a web application to Heroku or to Azure, maybe you don't pay the option to stay awake.
The server goes to sleep if do not have traffic for some minutes so if you use it, it can take some seconds to replies.

#How to use Glossina.
Just open the application and set the URL of the server.
Then Glossina sends a GET request every random (1-20) minutes to the server for staying it awake.

#Tips
If you want to induce complete insomnia on the server, then just set define URL from source code and set Glossina to auto start up programs.
So as long as your computer is on, the Glossina keeps the server awake automatically.
