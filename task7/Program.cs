
using System.Globalization;

int N = int.Parse(Console.ReadLine());
var a = new List<string>();
while(N-- > 0){
    var input = Console.ReadLine();
    a.Add(input);
}
int M = int.Parse(Console.ReadLine());
while(M-- > 0){
    var input = Console.ReadLine();
    var duplicate = false;
    for(int i=0; i < a.Count && !duplicate; i++){
        duplicate = ProcessItem(a[i], input);
        // if(duplicate){
        //     Console.WriteLine($"{a[i]} == {input}");
        // }
    }
    Console.WriteLine(duplicate ? 1 : 0);
}

bool ProcessItem(string item, string input)
{
    if(item.Length != input.Length) return false;
    var diff = 1;
    for(int j=0 ; j < input.Length && diff >= 0; j++){
        if(input[j] != item[j]){
            if(j + 1 == input.Length){
                diff = -1;
            }
            else if(input[j] == item[j + 1] && item[j] == input[j + 1]){
                diff--;
                j++;
            }
            else{
                diff = -1;
            }
            
        }
    }
    return diff >= 0;
}