using GestorTareas;

var store = new TaskStore("tareas.json");
var service = new TaskService(store);

while (true)
{
    Console.WriteLine();
    Console.WriteLine("=== GESTOR DE TAREAS ===");
    Console.WriteLine("0. Salir");
    Console.Write("Opción: ");

    var option = Console.ReadLine();
    if (option is null || option == "0") break;

    switch (option)
    {
        default:
            Console.WriteLine("Opción no válida.");
            break;
    }
}
