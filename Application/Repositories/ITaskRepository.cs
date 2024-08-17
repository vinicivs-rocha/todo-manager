namespace Application.Repositories;

public interface ITaskRepository
{
    void CreateTask(Task task);
    Task? GetTaskById(string id);
    List<Task> GetTasks();
    void UpdateTask(Task task);
    void DeleteTask(string id);
}