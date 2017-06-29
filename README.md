# Glossina
<i>Glossina is an application for staying awake a server.</i>
<p><a href="https://github.com/PCMacOS/Glossina/blob/master/Glossina.exe?raw=true">Download the executable.</a></p>
<center><img src="https://github.com/PCMacOS/Glossina/blob/master/Glossina/Glossina.ico?raw=true" alt="Glosina_Logo" style="width:304px;height:228px;"></center>
<h3>#Why use Glossina?</h3>
If you have deployed a web application to Heroku or to Azure, maybe you don't pay the option to stay awake.
The server goes to sleep if do not have traffic for some minutes so if you use it, it can take some seconds to replies.
<br>
<h3>#How to use Glossina.</h3>
Just open the application and set the URL of the server.
Then Glossina sends a GET request every random (1-20) minutes to the server for staying it awake.
<br>
<h3>#Tips</h3>
<ul>
  <li>If you want to induce complete insomnia on the server, then just set define URL from source code and set Glossina to auto start up programs.
So as long as your computer is on, the Glossina keeps the server awake automatically.</li>
  <li>If you want, call the "hide method" at first line of "main()" to hide it automatically.</li>
</ul> 
