namespace GestorTareas;

public partial class TaskService
{
    public IReadOnlyList<TaskItem> GetAll() => _tasks;

    public TaskItem? GetById(int id) => _tasks.FirstOrDefault(t => t.Id == id);
}
