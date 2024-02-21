# FootballLeagueManager
  
Kroki i decyzje:
1. Analiza wymogów zadania
2. Dobór technologi i szablonu startowego
3. Dodanie funkcjonalności do administracji/zarządzania aplikacją (logi, sekrety)
4. Projektowanie i implementacja modeli encji.
5. Implementacja logiki repozytoriów
6. Implementacja samoczynnej rejestracji zależności w kontenerze (Dependency injection)
7. Implementacja kreowania przykładowych rekordów
8. Implementacja wyświetlania tabel ligowych
9. Implementacja wyświetlania meczów drużyn
10. Implementacja dodawania do ulubionych
11. Implementacja wyświetlania ulubionych drużyn
12. Testy, weryfikacje, uzupełnienia
13. Refaktoryzacja - dodanie do modeli encji połączonych. Pobieranie wymaganych rekordów jednym zapytaniem
  
  
Co jeszcze można dodać:
1. Paginacja dla tabel ligowych
2. Funkcjonalność host admina, który będzie mógł zarządzać użytkownikami i rolami
3. Dodać CRUD'a dla wszystkich encji żeby użytkownicy z odpowiednią rolą mogli dodawać nowe drużyny, mecze itp.
4. Dodać repozytorium dla CRUD'a które będzie generyczne z podziałem na warstwy typu Dto, UpdateDto, CreateDto itp.
5. Dodać takie tabele jak zawodnik, faul, bramka i inne
  
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
  