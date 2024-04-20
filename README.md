# Football League Manager
  
  
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
  
