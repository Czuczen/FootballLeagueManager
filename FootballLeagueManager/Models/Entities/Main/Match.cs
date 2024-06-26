﻿namespace FootballLeagueManager.Models.Entities.Main;

public class Match : Entity<int>
{
    public int HomeTeamGoals { get; set; }

    public int AwayTeamGoals { get; set; }

    public DateTime Date { get; set; }

    public int Queue { get; set; }

    public int HomeTeamId { get; set; }

    public Team HomeTeam { get; set; }

    public int AwayTeamId { get; set; }

    public Team AwayTeam { get; set; }

    public int SeasonId { get; set; }
}
