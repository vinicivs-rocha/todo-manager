using Application.Repositories;

namespace Infra.Repositories;

public class InMemoryTaskRepository : ITaskRepository
{
    private readonly List<Task> _tasks = [];


    public void CreateTask(Task task)
    {
        _tasks.Add(task);
    }

    public Task? GetTaskById(string id)
    {
        return _tasks.First(task => task.Id.ToString() == id);
    }

    public List<Task> GetTasks()
    {
        return _tasks;
    }

    public void UpdateTask(Task task)
    {
        var index = _tasks.FindIndex(t => t.Id == task.Id);
        _tasks[index] = task;
    }

    public void DeleteTask(string id)
    {
        _tasks.RemoveAll(task => task.Id.ToString() == id);
    }
}