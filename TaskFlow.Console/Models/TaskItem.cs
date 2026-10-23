
namespace TaskFlow.Console.Models;

public class TaskItem
{
    public Guid Id { get; }
    public string Title { get; }
    public bool IsCompleted { get; private set; }

    public TaskItem(string title)
    {
        Id = Guid.NewGuid();
        Title = title;
        IsCompleted = false;
    }

    public void ToggleCompletion()
    {
        IsCompleted = !IsCompleted;
    }
}
