namespace GestorTareas;

public partial class TaskService
{
    public bool Update(int id, string title, string description, bool isCompleted)
    {
        var task = GetById(id);
        if (task is null) return false;

        task.Title = title.Trim();
        task.Description = description.Trim();
        task.IsCompleted = isCompleted;
        store.Save(_tasks);
        return true;
    }
}
