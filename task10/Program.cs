class Program()
{
    static void Main(){
        var t = int.Parse(Console.ReadLine());
        while(t-- > 0){
            var N = int.Parse(Console.ReadLine());
            var connection = new Dictionary<int, List<int>>();
            var dict = new Dictionary<int, string>();
            for(int i=0; i < N; i++){
                var data = Console.ReadLine().Split(" ").ToList();
                var id = int.Parse(data[0]);
                var parentId = int.Parse(data[1]);
                var text = string.Join(" ", data.Skip(2));
                if(!connection.ContainsKey(parentId)){
                    connection[parentId] = new List<int>();
                }
                connection[parentId].Add(id);
                dict.Add(id, text);
            }

            void Process(int id, int deep){
                if(dict.ContainsKey(id)){
                    var tire = deep > 0 ? "--" : "";
                    var palka = string.Join("  ", Enumerable.Repeat("|", deep));
                    Console.WriteLine(palka + tire + dict[id]);
                }
                if(connection.ContainsKey(id)){
                    Console.WriteLine(string.Join("  ", Enumerable.Repeat("|", deep + 1)));
                    foreach(var item in connection[id].OrderBy(x => x)){
                        Process(item, deep + 1);
                    }
                }
                else{
                    Console.WriteLine();
                }
            }

            Process(-1, -1);
        }
    }
}
