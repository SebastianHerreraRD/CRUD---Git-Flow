using GestorTareas;

var store = new TaskStore("tareas.json");
var service = new TaskService(store);

while (true)
{
    Console.WriteLine();
    Console.WriteLine("=== GESTOR DE TAREAS ===");
    Console.WriteLine("1. Crear tarea");
    Console.WriteLine("2. Listar tareas");
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
