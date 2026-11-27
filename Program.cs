using GestorTareas;

var store = new TaskStore("tareas.json");
var service = new TaskService(store);

while (true)
{
    Console.WriteLine();
    Console.WriteLine("=== GESTOR DE TAREAS ===");
    Console.WriteLine("1. Crear tarea");
    Console.WriteLine("0. Salir");
    Console.Write("Opción: ");

    var option = Console.ReadLine();
    if (option is null || option == "0") break;

    switch (option)
    {
        case "1":
            CreateTask();
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
