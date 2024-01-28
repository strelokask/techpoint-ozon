﻿using System.Text;

int t = int.Parse(Console.ReadLine());
while(t-- > 0){
    var input = Console.ReadLine();
    var ans = new List<List<char>>(){
        new List<char>()
    };
    int i = 0;
    int j = 0;
    foreach(var ch in input){
        switch (ch){
            case 'L':
                j = Math.Max(0, j - 1);
                break;
            case 'R':
                j = Math.Min(ans[i].Count, j + 1);
                break;
            case 'U':
                i = Math.Max(i - 1, 0);
                j = Math.Min(j, ans[i].Count);
                break;
            case 'D':
                i = Math.Min(ans.Count - 1, i + 1);
                j = Math.Min(j, ans[i].Count);
                break;
            case 'B':
                j = 0;
                break;
            case 'E':
                j = ans[i].Count;
                break;
            case 'N':
                var newLine = new List<char>();
                for(int k = j; k < ans[i].Count; k++){
                    newLine.Add(ans[i][k]);
                }
                ans[i].RemoveRange(j, ans[i].Count - j);
                ans.Insert(i+1, newLine);
                j = 0;
                i += 1;
                break;
            default:
                ans[i].Insert(j, ch);
                j += 1;
                break;
        }
        // Console.WriteLine("\t" + ch + " => " + i + " " + j);
        // foreach(var item in ans){
        //     Console.WriteLine(new string(item.ToArray()));
        // }
    }
    foreach(var item in ans){
        Console.WriteLine(new string(item.ToArray()));
    }
    Console.WriteLine("-");
}
