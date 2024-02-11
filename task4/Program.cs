var t = int.Parse(Console.ReadLine());
while(t-- > 0){
    var input = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToList();
    var R = input[0];
    var C = input[1];
    var d = new List<List<char>>();
    var A = Tuple.Create(0, 0);
    var B = Tuple.Create(0, 0);
    for(int i=0; i < R; i++){
        var data = Console.ReadLine().ToList();
        for(int j=0; j < C; j++){
            if(data[j] == 'A'){
                A = Tuple.Create(i, j);
            }
            if(data[j] == 'B'){
                B = Tuple.Create(i, j);
            }
        }
        d.Add(data);
    }
    void GoToUp(Tuple<int, int> t, char ch){
        var row = 1;
        var col = 0;
        while(col <= t.Item2){
            if(col == t.Item2 && (col % 2 == 1 || d[0][col] != '.')){
                break;
            }
            d[0][col] = ch;
            col++;
        }
        col--;
        while(row <= t.Item1){
            d[row][col] = ch;
            row++;
        }
        d[t.Item1][t.Item2] = Char.ToUpper(ch);

    }
    void GoToDown(Tuple<int, int> t, char ch){
        var row = R - 1;
        var col = C - 1;
        while(col >= t.Item2){
            if(col == t.Item2 && col % 2 == 1){
                break;
            }
            d[row][col] = ch;
            col--;
        }
        col++;
        while(row >= t.Item1){
            if(row == t.Item1 && d[row][col] != '.'){
                break;
            }
            d[row][col] = ch;
            row--;
        }
        d[t.Item1][t.Item2] = Char.ToUpper(ch);
    }
    // foreach(var item in d){
    //     Console.WriteLine(new string(item.ToArray()));
    // }
    // Console.WriteLine($"{A} {B}");
    if(A.Item1 > B.Item1 || (A.Item1 == B.Item1 && A.Item2 > B.Item2)){
        GoToUp(B, 'b');
        GoToDown(A, 'a');
    }
    else{
        GoToUp(A, 'a');
        GoToDown(B, 'b');
    }

    foreach(var item in d){
        Console.WriteLine(new string(item.ToArray()));
    }
    // Console.WriteLine();
}