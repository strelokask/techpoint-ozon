int t = int.Parse(Console.ReadLine());
while(t-- > 0){
    var input = Console.ReadLine();
    var state = -1;
    var wrong = false;
    for(int i=0; i < input.Length && !wrong; i++){
        switch (input[i]){
            case 'M':
                wrong = state != -1;
                state = 0;
                break;
            case 'R':
                wrong = state == - 1 || state == 1;
                state = 1;
                break;
            case 'C':
                wrong = state != 1 && state != 0;
                state = -1;
                break;
            case 'D':
                wrong = state == -1;
                state = -1;
                break;
            default:
                break;
        } 
    }
    Console.WriteLine(wrong || state != -1 || input[input.Length - 1] != 'D' ? "NO" : "YES");
}
