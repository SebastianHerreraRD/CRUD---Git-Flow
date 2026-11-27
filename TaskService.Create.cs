namespace GestorTareas;

public partial class TaskService
{
    public TaskItem Create(string title, string description)
    {
        var task = new TaskItem
        {
            Id = _tasks.Count == 0 ? 1 : _tasks.Max(t => t.Id) + 1,
            Title = title.Trim(),
            Description = description.Trim()
        };
        _tasks.Add(task);
        store.Save(_tasks);
        return task;
    }
}
