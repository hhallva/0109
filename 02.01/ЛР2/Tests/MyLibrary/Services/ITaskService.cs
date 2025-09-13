using MyLibrary.Models;

namespace MyLibrary.Services
{
    public interface ITaskService
    {
        List<TaskModel> GetAllTasks();
        TaskModel? GetTaskById(int id);
        TaskModel CreateTask(TaskModel task);
        TaskModel? UpdateTask(int id, TaskModel task);
        bool DeleteTask(int id);
    }
}
