namespace GestorTareas;

public partial class TaskService(TaskStore store)
{
    private readonly List<TaskItem> _tasks = store.Load();
}
