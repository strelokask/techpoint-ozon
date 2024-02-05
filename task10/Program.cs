var t = int.Parse(Console.ReadLine());
while(t-- > 0){
    var N = int.Parse(Console.ReadLine());
    var comments = new Dictionary<int, string>();
    var isNodeLastOnLevel = new Dictionary<int, bool>();
    var tree = new Dictionary<int, PriorityQueue<int, int>>();
    for(int i=0; i < N; i++){
        var input = Console.ReadLine().Split(" ").ToList();
        var id = int.Parse(input[0]);
        var parentId = int.Parse(input[1]);
        var text = string.Join(" ", input.Skip(2));
        comments.Add(id, text);
        if(!tree.ContainsKey(parentId)){
            tree.Add(parentId , new PriorityQueue<int, int>());
        }
        tree[parentId].Enqueue(id, id);
    }
    void PrintNode(int nodeId, int lvl){
        if(lvl >= 0){
            var line = new List<string>();
            for(int i=1; i <= lvl; i++){
                line.Add(i != lvl && isNodeLastOnLevel[i] ? "" : "|");
            }
            if(lvl > 0){
                Console.WriteLine(string.Join("  ", line));
                Console.Write(string.Join("  ", line));
                Console.Write($"--");
            }
            Console.WriteLine($"{comments[nodeId]}");
        }
        if(tree.ContainsKey(nodeId)){
            var cnt = tree[nodeId].Count;
            while(cnt-- > 0){
                var child = tree[nodeId].Dequeue();
                if(!isNodeLastOnLevel.ContainsKey(lvl + 1)){
                    isNodeLastOnLevel.Add(lvl + 1, cnt > 0);
                }
                isNodeLastOnLevel[lvl + 1] = cnt == 0;
                PrintNode(child, lvl + 1);
            }
        }
        if(lvl == 0) Console.WriteLine();
    }
    PrintNode(-1, -1);
}