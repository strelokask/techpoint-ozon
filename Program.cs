﻿var input = Console.ReadLine();

int t = int.Parse(input);
for(int i=0; i < t; i++){
    var arr = Console.ReadLine();
    var a = arr.Split(' ').Select(x => int.Parse(x)).ToList();
    var d = a[0];
    var m = a[1];
    var y = a[2];
    bool isValid = d >= 1 && d <= 31 && m >= 1 && m <= 12 && y >= 1950 && y <= 2300;
    if(isValid){
        if(m == 2){
            if(isFullYear(y)){
                isValid = d >= 1 && d <= 29;
            }
            else{
                isValid = d >= 1 && d <= 28;
            }
        }
        else {
            if(m == 1 || m == 3 || m == 5 || m == 7 || m == 8 || m == 10 || m == 12){
                isValid = d >= 1 && d <= 31;
            }
            else{
                isValid = d >= 1 && d <= 30;
            }
        }
    }

    Console.WriteLine(isValid ? "YES" : "NO");
}

bool isFullYear(int year){
    return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
}