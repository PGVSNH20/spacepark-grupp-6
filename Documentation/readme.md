# Documentation
To-Do Lista:
1. Vidareutveckla metoden som tar in personer från https://swapi.dev/people. Den ska nu kunna gå igenom alla sidor och ta ut alla karaktärer.
2. Skapa en metod som går igenom <inputs> skepp, de ska sedan kan välja sina fordon (i en lista?) för att kunna parkera.
3. Skapa en metod som räknar ut hur stor yta av parkeringshuset som är upptagen.
4. 
5. (Extra punkt. Om någon har lust så är det bara börja på att utveckla gränssnittet lite) 

2021-03-18
Första intrycket

[Spaceport]

Spontant så hade det varit roligt att göra en hemsida som UI
där man kan välja namn, rymdskepp, parkeringsplats av dom som är lediga
samt tid man vill parkera som man anropar ett API(Logikdelen) med "fluent".

För att uppfylla projektkraven så kan man anropa starwars APIet och
visa namn och rymdskepp därifrån men anropa det egna APIet för
lediga platser.

Return bör ge en biljett med ett pris och betalningsinformation.

Installera Entitity Framework - Done
Installera RestSharp - Done


2021-03-19

Eftersom SpacePark endast är öppen för alla som varit med i Star Wars filmerna,
så vi behöver ett sätt att titta igenom alla Star Wars-avatarer för att göra en kontroll på personen som vill parkera i huset. 

15:30
Vi har nu skapat klasser till en function som tar in personer på första sidan: https://swapi.dev/people,
även lyckats få ut informationen på webapplikationen.


16:24
Jag lyckades fixa validering emot Swapi med Emils StarWarsUniverse model.
Om jag får tid över ska jag försöka skicka ut informationen på sidan också, (för tilllfället skickas man bara tilll Error eller Index beroende på om man har korrekt input)

2021-03-22

10:30
Updaterade ToDo-listan
