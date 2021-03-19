# Documentation
To-Do Lista:
1. Skapa input på applikationen, Man ska kunna skriva in namn i input
2. Skapa knapp på applikationen, När man klickar så ska den ta in resultatet från input med namn.
3. Skapa en funktion som körs när man klickat på knappen. Funktionen ska jämföra namnet i input med namnen i listan från https://swapi.dev/people (i dagsläget page/1/)
4. Vidareutveckla funktionen som tar in personer från https://swapi.dev/people. Den ska nu kunna gå igenom alla sidor och ta ut alla karaktärer.
5. (Ska Yoda kunna köra Gokart?)

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
