using System.ComponentModel;

int t = int.Parse(Console.ReadLine());
var VALUES = new[] {'2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A'};
var SUITS = new [] {'S', 'C', 'D', 'H'};
while(t-- > 0){
    var N = int.Parse(Console.ReadLine());
    var player1s = new List<string>[N];
    for (int i = 0; i < N; i++)
    {
        players[i] = Console.ReadLine().Split().ToList();
        if(i > 0 && players[i][0][0] == players[i][1][0]){
            players[i].AddRange(
                SUITS.Select(x => ""+players[i][0][0]+x)
            );
        }
    }

    List<string> possibleCards = new (); 
    var maxValuePlayers = players.Select(
        p => Math.Max(
            Array.FindIndex(VALUES, value => value == p[0][0]),
            Array.FindIndex(VALUES, value => value == p[1][0])
        )
    ).ToList();
    var maxValue = maxValuePlayers.Max();
    List<string> allPossibleCombination = new();
    foreach(var val in VALUES){
        foreach(var s in SUITS){
            allPossibleCombination.Add("" + val + s);
        }
    }
    //‘Сет со значением x’
    if(players[0][0][0] == players[0][1][0]){
        var addingData = maxValuePlayers[0] >= maxValue
            ? allPossibleCombination
            : SUITS.Select(x => ""+players[0][0][0]+x)
            ;

        possibleCards.AddRange(
            addingData
            .Where(x => !players.Any(p => p.Contains(x)))
        );
    }
    //Пара со значением x
    else {
        possibleCards.AddRange(
            // SUITS
            //     .Select(x => ""+VALUES[maxValuePlayers[0]]+x)
            allPossibleCombination
                .Where(x => !players.Any(p => p.Contains(x)))
        );
        for(int i = 1; i < N; i++){
            if(players[i][0][0] == players[i][1][0]){
                if(maxValuePlayers[i] >= maxValuePlayers[0]){
                    possibleCards.Clear();
                    break;
                }
                else{
                    possibleCards = possibleCards
                        .Where(x => x[0] == VALUES[maxValuePlayers[0]])
                        .ToList();
                        
                }
            }
        }
    }

    Console.WriteLine(possibleCards.Count);
    foreach (var card in possibleCards)
    {
        Console.WriteLine(card);
    }
}
