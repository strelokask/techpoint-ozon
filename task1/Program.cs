var input = Console.ReadLine();

int t = int.Parse(input);
for(int i=0; i < t; i++){
    var arr = Console.ReadLine();
    var a = arr.Split(' ').Select(x => int.Parse(x)).ToList();
    
    int[] expected = {4, 3, 2, 1};
    bool isValid = true;
    for(int j=0; j < a.Count && isValid; j++){
        expected[a[j] - 1]--;
        isValid = expected[a[j] - 1] >= 0;
    }
    Console.WriteLine(isValid ? "YES" : "NO");
}