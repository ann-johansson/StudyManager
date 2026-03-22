## Vad min applikation gör:
Detta är en Study taskmanager. Man kan skriva upp uppgifter som man har att göra,
tillsammans med vilket ämne och förklaring av uppgiften. Man kan även sätta en deadline för vilken
dag den skall in.

## Hur kör man appen?
Ladda ner repositoriet och öppna det i Visual Studio.
Se till att ha SQL Server installerat, öppna "Package Manager Console" i Visual Studio och skriv
"Update-Database" för att skapa Databasen till programmet.
Kör nu programmet i Visual Studio och låt det stå igång.
Öppna Visual Studio Code, se till att du har LiveServer extensionet.
Öppna "StudyManager" repot i VS Code och kör det via LiveServer.

## Vilka endpoints finns?
1. GET - Hämtar alla uppgifter
2. GET med Id - Hämtar en specifik uppgift.
3. POST - Skapar en ny uppgift.
4. PUT med Id - Uppdaterar en hel uppgift.
5. PUT med Id och status - Uppdaterar endast statusen (om uppgiften är klar).
6. DELETE - Raderar en uppgift.

## Hur pratar frontend med API:et?
Den använder fetch() funktionen i Javascript för att asynkront göra HTTP-anrop till API:et.

## Reflektion:
Jag tycker att API:et denna gång gick mycket enklare (då jag tränat på detta och det är C#). Jag testade även att 
använda nuGet paketet Mapster som verkligen gjorde paketeringen av DTOer mycket smidigare och koden renare. Jag testade
även att använda mig av ett service interface, även om det inte kan behövas i en så här liten applikation kan det redan nu
vara bra att börja öva på att lägga grunden för mer avancerade applikationer och en bra hantering av dessa.
Jag tyckte Javascript var det svåraste då syntaxen påminer en hel del om C# men de har en del starka skillnader. Särskillt 
innom användandet av apostrofer.
När det kommer till styrkor tänker jag att dess rena struktur och enkelhet i UI gör den enkel att använda för alla.
Just nu så är dess CORS setting öppen för allt och alla. Om man vill utveckla appen mer så kan det vara bra att ändra den
till att interagera enbart med frontenden och eventullt förtrodda sidor. Det finns många saker som kan förbättras, man kan utveckla
och lägga till nya funktioner. Ändra och experimentera med UI, uppdatera designen i frontenden, kanske lägga in bilder och mer
animationer.
