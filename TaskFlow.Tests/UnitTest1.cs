
using TaskFlow.Console;

namespace TaskFlow.Tests;

public class UnitTest1
{
    [Fact]
    public void DeveAdicionarTarefaComTituloValido()
    {
        var manager = new TaskManager();

        var task = manager.AddTask("Estudar C#");

        Assert.NotNull(task);
        Assert.Equal("Estudar C#", task.Title);
        Assert.False(task.IsCompleted);
    }

    [Fact]
    public void NaoDeveAdicionarTarefaComTituloVazio()
    {
        var manager = new TaskManager();

        var task = manager.AddTask("");

        Assert.Null(task);
    }

    [Fact]
    public void NaoDeveAdicionarTarefaComTituloNulo()
    {
        var manager = new TaskManager();

        var task = manager.AddTask(null);

        Assert.Null(task);
    }

    [Fact]
    public void DeveListarTarefasAdicionadas()
    {
        var manager = new TaskManager();

        manager.AddTask("Estudar C#");
        manager.AddTask("Fazer exercícios");

        Assert.Equal(2, manager.ListTasks().Count);
    }

    [Fact]
    public void DeveConcluirUmaTarefa()
    {
        var manager = new TaskManager();
        var task = manager.AddTask("Estudar C#")!;

        bool result = manager.CompleteTask(task.Id);

        Assert.True(result);
        Assert.True(task.IsCompleted);
    }
    
[Fact]
public void DeveRetornarNullQuandoTarefaNaoExistir()
{
    var manager = new TaskManager();

    var task = manager.FindById(Guid.NewGuid());

    Assert.Null(task);
}

}
