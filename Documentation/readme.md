# Documentation
To-Do Lista:
1. Göra en sida där man kan "identifiera" sig och få ut en lista med alla köpta biljetter för denna personen.
2. När denne person identifierat sig ska en kunna välja sin "Aktiva" biljett och kunna betala nuvarande summa för att åka därifrån (vilket gör att endtime slutar .now)?
3. Göra så att databasen tar emot ett X antal aktiva platser. (Skapa en metod som räknar ut hur många aktiva platser som finns att hyra.)
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

2021-03-22

12:30
Nu har vi skapat en databas genom Add Migration
Databasen sparar:id, namn, fordon, start/sluttid på parkering, antal minuter, kostnad och parkeringsplats

13:44
Updaterade ToDo-Listan med lite nya uppgifter man kan göra om man känner att man har tid.
