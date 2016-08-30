# Link

The task was to create a web application called Link (app), a RESTful web service called Zelda (service) and a database called Ganondorf (db).

App should allow the visitor to enter between 5-10 websites together with information about these sites (name, description, owner, category, points) on an input form. User input should be validated and user should be notified of any shortcomings.

All correctly entered data should be stored in the db.

Service should query the db and return top 10 websites with most points and aggregate the results.

App should request the service for top 10 websites and display the aggregated results to the user.


Unfortunately my azure trial has ran out so the links return a 403.

http://link111.azurewebsites.net/
http://zelda111.azurewebsites.net/
http://zelda111.azurewebsites.net/sites?nrResults=10&sortBy=points&reverse=true
http://zelda111.azurewebsites.net/sites?nrResults=4&sortBy=points&reverse=false
