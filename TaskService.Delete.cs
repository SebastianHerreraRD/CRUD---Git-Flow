namespace GestorTareas;

public partial class TaskService
{
    public bool Delete(int id)
    {
        var task = GetById(id);
        if (task is null) return false;

        _tasks.Remove(task);
        store.Save(_tasks);
        return true;
    }
}
