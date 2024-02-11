using System.Diagnostics.SymbolStore;
using System.Numerics;
using System.Text.Json;

int t = int.Parse(Console.ReadLine());
while(t-- > 0){
    var N = int.Parse(Console.ReadLine());
    var a = new List<string>();
    for(int i=0; i < N; i++){
        a.Add(Console.ReadLine());
    }
    var jsonDoc = JsonDocument.Parse(string.Join("\n", a), new JsonDocumentOptions{
        MaxDepth = 1000
    });
    var root = jsonDoc.RootElement;
    int ProcessFolder(JsonElement json, bool isParentVirus){
        var ans = 0;
        var isDirHasVirus = isParentVirus;
        if (json.TryGetProperty("files", out var filesElement) && filesElement.ValueKind == JsonValueKind.Array){
            foreach(var file in filesElement.EnumerateArray()){
                isDirHasVirus = isDirHasVirus || file.GetString().Contains(".hack");
                if(isDirHasVirus){
                    break;
                }
            }
            if(isDirHasVirus){
                foreach(var file in filesElement.EnumerateArray()){
                    ans++;
                }
            }
        }
        if (json.TryGetProperty("folders", out var foldersElement) && foldersElement.ValueKind == JsonValueKind.Array){
            foreach(var folder in foldersElement.EnumerateArray()){
                var folderCount = ProcessFolder(folder, isDirHasVirus);
                ans += folderCount;
            }
        }
        return ans;
    }
    var ans = ProcessFolder(root, false);
    Console.WriteLine(ans);
}
