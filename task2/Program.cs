using System.ComponentModel;

int t = int.Parse(Console.ReadLine());
while(t-- > 0){
    var input = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();
    var N = input[0];
    var P = input[1];
    var ans = 0.0;
    
    for(int i=0; i < N; i++){
        var a = int.Parse(Console.ReadLine());
        var profit = a*(P / 100.0);
        var wrong = Math.Truncate(profit);
        ans += profit - wrong;
    }

    Console.WriteLine(String.Format("{0:0.00}", Math.Round(ans, 2)));
}
