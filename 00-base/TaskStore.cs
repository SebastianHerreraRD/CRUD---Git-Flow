using System.Text.Json;

namespace GestorTareas;

public class TaskStore(string path)
{
    public List<TaskItem> Load()
    {
        if (!File.Exists(path)) return [];
        return JsonSerializer.Deserialize<List<TaskItem>>(File.ReadAllText(path)) ?? [];
    }

    public void Save(List<TaskItem> tasks)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        File.WriteAllText(path, JsonSerializer.Serialize(tasks, options));
    }
}
