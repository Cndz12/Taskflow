
using TaskFlow.Console.Models;

namespace TaskFlow.Console;

public class TaskManager
{
    private readonly Dictionary<Guid, TaskItem> tasks = new();

    public TaskItem? AddTask(string? title)
    {
        if (string.IsNullOrWhiteSpace(title))
            return null;

        var task = new TaskItem(title.Trim());
        tasks.Add(task.Id, task);

        return task;
    }

    public IReadOnlyCollection<TaskItem> ListTasks()
    {
        return tasks.Values.ToList().AsReadOnly();
    }

    public bool CompleteTask(Guid id)
    {
        if (!tasks.TryGetValue(id, out var task))
            return false;

        task.ToggleCompletion();
        return true;
    }

    public TaskItem FindById(Guid id)
    {
        return tasks[id];
    }
}
