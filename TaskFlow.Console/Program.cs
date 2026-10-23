
using TaskFlow.Console;

var manager = new TaskManager();

while (true)
{
    System.Console.WriteLine("\n=== TASKFLOW ===");
    System.Console.WriteLine("1 - Adicionar tarefa");
    System.Console.WriteLine("2 - Listar tarefas");
    System.Console.WriteLine("3 - Concluir tarefa");
    System.Console.WriteLine("4 - Buscar tarefa por ID");
    System.Console.WriteLine("0 - Sair");
    System.Console.Write("Escolha: ");

    string? option = System.Console.ReadLine();

    switch (option)
    {
        case "1":
            System.Console.Write("Título da tarefa: ");
            string? title = System.Console.ReadLine();

            var task = manager.AddTask(title);

            System.Console.WriteLine(
                task == null
                    ? "Título inválido."
                    : $"Tarefa adicionada! ID: {task.Id}");
            break;

        case "2":
            var tasks = manager.ListTasks();

            if (tasks.Count == 0)
            {
                System.Console.WriteLine("Nenhuma tarefa cadastrada.");
                break;
            }

            foreach (var item in tasks)
            {
                string status = item.IsCompleted
                    ? "Concluída"
                    : "Pendente";

                System.Console.WriteLine(
                    $"{item.Id} | {item.Title} | {status}");
            }
            break;

        case "3":
            System.Console.Write("Digite o ID da tarefa: ");

            if (Guid.TryParse(
                System.Console.ReadLine(), out Guid completeId))
            {
                System.Console.WriteLine(
                    manager.CompleteTask(completeId)
                        ? "Status da tarefa alterado!"
                        : "Tarefa não encontrada.");
            }
            else
            {
                System.Console.WriteLine("ID inválido.");
            }
            break;

        case "4":
            System.Console.Write("Digite o ID da tarefa: ");

            if (Guid.TryParse(
                System.Console.ReadLine(), out Guid searchId))
            {
                var found = manager.FindById(searchId);

                if (found == null)
                    System.Console.WriteLine("Tarefa não encontrada.");
                else
                    System.Console.WriteLine(
                        $"{found.Title} | " +
                        $"{(found.IsCompleted ? "Concluída" : "Pendente")}");
            }
            else
            {
                System.Console.WriteLine("ID inválido.");
            }
            break;

        case "0":
            return;

        default:
            System.Console.WriteLine("Opção inválida.");
            break;
    }
}
