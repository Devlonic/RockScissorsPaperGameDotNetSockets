namespace rsp.server.game;

static class GameResultsCalculator {
    public static GameResults Calculate(PlayersList list) {
        List<PlayerResult> results = new List<PlayerResult>();
        foreach ( var p in list ) {
            results.Add(new(p.Name, p.Figure.Value));
        }
        return Calculate(results);
    }
    public static GameResults CalculateTemp(List<PlayerResult> results) {
        return Calculate(results);
    }

    private static GameResults Calculate(List<PlayerResult> results) {
        GameResults r = new GameResults();
        r.Results = results;

        if ( IsKashamalasha(( from res in results select res.Figure ).ToArray()) ) {
            r.ResultType = GameResultsType.Kashamalasha;
        }
        else if ( results.All(r => r.Figure == results[0].Figure) ) {
            r.ResultType = GameResultsType.NoWinners;
        }
        else {
            r.WinPlayers = GetWinners(results);

            if ( r.WinPlayers.Count == 1 ) {
                r.ResultType = GameResultsType.OneWinner;
                r.Winner = r.WinPlayers[0];
            }
            else
                r.ResultType = GameResultsType.ManyWinners;
        }
        return r;

    }

    private static bool IsKashamalasha(Figure[] figures) {
        if (
            figures.Contains(Figure.Rock) &&
            figures.Contains(Figure.Scissos) &&
            figures.Contains(Figure.Paper) )
            return true;
        else
            return false;
    }

    private static List<PlayerResult> GetWinners(List<PlayerResult> players) {
        List<PlayerResult> winners = new();

        Dictionary<Figure, List<PlayerResult>> res = new();
        res[Figure.Rock] = new List<PlayerResult>();
        res[Figure.Paper] = new List<PlayerResult>();
        res[Figure.Scissos] = new List<PlayerResult>();


        foreach ( var p in players ) {
            res[p.Figure].Add(p);
        }

        Figure dominantFigure = 
            GetDominantFigureAtWinnableSequence(( from p in players select p.Figure ).ToArray());
        winners = res[dominantFigure];
        
        return winners;
    }
    private static Figure GetDominantFigureAtWinnableSequence(Figure[] figures) {
        Figure currentDominant = figures[0];
        foreach ( var f in figures ) {
            switch ( f ) {
                case Figure.Rock:
                if ( currentDominant == Figure.Scissos )
                    currentDominant = Figure.Rock;
                break;
                case Figure.Scissos:
                if ( currentDominant == Figure.Paper )
                    currentDominant = Figure.Scissos;
                break;
                case Figure.Paper:
                if ( currentDominant == Figure.Rock )
                    currentDominant = Figure.Paper;
                break;
                default:
                break;
            }
        }
        return currentDominant;
    }
}

