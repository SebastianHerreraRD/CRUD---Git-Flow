using GestorTareas;

var store = new TaskStore("tareas.json");
var service = new TaskService(store);

while (true)
{
    Console.WriteLine();
    Console.WriteLine("=== GESTOR DE TAREAS ===");
    Console.WriteLine("1. Crear tarea");
    Console.WriteLine("2. Listar tareas");
    Console.WriteLine("3. Actualizar tarea");
    Console.WriteLine("4. Eliminar tarea");
    Console.WriteLine("0. Salir");
    Console.Write("Opción: ");

    var option = Console.ReadLine();
    if (option is null || option == "0") break;

    switch (option)
    {
        case "1":
            CreateTask();
            break;
        case "2":
            ListTasks();
            break;
        case "3":
            UpdateTask();
            break;
        case "4":
            DeleteTask();
            break;
        default:
            Console.WriteLine("Opción no válida.");
            break;
    }
}

void CreateTask()
{
    Console.Write("Título: ");
    var title = Console.ReadLine() ?? "";
    Console.Write("Descripción: ");
    var description = Console.ReadLine() ?? "";

    var error = TaskValidator.Validate(title, description);
    if (error is not null)
    {
        Console.WriteLine(error);
        return;
    }

    var task = service.Create(title, description);
    Console.WriteLine($"Tarea creada con ID {task.Id}.");
}

void ListTasks()
{
    var tasks = service.GetAll();
    if (tasks.Count == 0)
    {
        Console.WriteLine("No hay tareas registradas.");
        return;
    }

    foreach (var task in tasks)
    {
        var status = task.IsCompleted ? "Completada" : "Pendiente";
        Console.WriteLine($"[{task.Id}] {task.Title} - {status}");
        Console.WriteLine($"    {task.Description}");
    }
}

void UpdateTask()
{
    var id = ReadId();
    var task = service.GetById(id);
    if (task is null)
    {
        Console.WriteLine("No existe una tarea con ese ID.");
        return;
    }

    Console.Write($"Nuevo título (Enter conserva '{task.Title}'): ");
    var title = Console.ReadLine();
    if (string.IsNullOrEmpty(title)) title = task.Title;
    Console.Write("Nueva descripción (Enter conserva la actual): ");
    var description = Console.ReadLine();
    if (string.IsNullOrEmpty(description)) description = task.Description;
    Console.Write("¿Completada? (s/n, Enter conserva): ");
    var answer = Console.ReadLine()?.Trim().ToLower();
    var completed = answer == "s" || (answer != "n" && task.IsCompleted);

    var error = TaskValidator.Validate(title, description);
    if (error is not null)
    {
        Console.WriteLine(error);
        return;
    }

    service.Update(id, title, description, completed);
    Console.WriteLine("Tarea actualizada.");
}

void DeleteTask()
{
    var id = ReadId();
    Console.Write("¿Confirma la eliminación? (s/n): ");
    if (Console.ReadLine()?.Trim().ToLower() != "s") return;

    Console.WriteLine(service.Delete(id) ? "Tarea eliminada." : "No existe una tarea con ese ID.");
}

int ReadId()
{
    Console.Write("ID de la tarea: ");
    return int.TryParse(Console.ReadLine(), out var id) ? id : 0;
}
