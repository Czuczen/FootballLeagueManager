# Football League Manager  
  
Football League Manager to aplikacja webowa stworzona w ramach projektu .NET, która umożliwia użytkownikom przeglądanie lig piłkarskich. Aplikacja prezentuje tabelę ligową oraz wyniki meczów.  
  
## Funkcjonalności  
- Przeglądanie Tabeli Ligowej: Użytkownicy mogą przeglądać aktualne tabele ligowe z podstawowymi informacjami o drużynach.  
- Przeglądanie Wyników Meczów: Aplikacja dostarcza informacje o wynikach meczów.  
- Szczegóły Drużyny: Po kliknięciu na nazwę drużyny w tabeli, użytkownicy mogą zobaczyć szczegółowe wyniki tej drużyny na tej samej stronie.  
- Zarządzanie Ulubionymi Drużynami: Zalogowani użytkownicy mają możliwość dodawania oraz usuwania drużyn z listy ulubionych, co umożliwia łatwiejsze śledzenie wybranych zespołów.  
  
## Technologie  
ASP.NET Core 8 MVC  
Entity Framework Core  
  
C#  
JavaScript  
jQuery  
HTML  
CSS  
Bootstrap  
  
## Jak uruchomić aplikację  
  
1. W projekcie "**FootballLeagueManager**" dodaj plik "**secrets.json**" i uzupełnij go według szablonu:  
```  
	{
	  "ConnectionStrings": {
	    "FootballLeagueManager": {
	      "DefaultConnection": "",
	      "TestConnection": ""
	    }
	  },
	  "AccessKeys": {
	    "Logs": "key"
	  }
	}
```  
2. W wartości klucza "**DefaultConnection**" wprowadź informacje dotyczące połączenia z bazą danych MSSQL.
3. Na górnym pasku menu wybierz "Narzędzia", a następnie z rozwijanej listy najedź na "Menedżer pakietów NuGet" i z kolejnej listy wybierz "Konsola menedżera pakietów".  
4. W konsoli menedżera pakietów dla pola "Projekt domyślny" z rozwijanej listy wybierz "FootballLeagueManager".  
5. W konsoli menedżera pakietów wpisz komende "Update-Database" i wciśnij Enter.  
6. Uruchom aplikację (Ctrl+F5).  
  
