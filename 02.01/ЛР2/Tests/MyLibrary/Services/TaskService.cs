using MyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyLibrary.Services
{
    public class TaskService : ITaskService
    {
        private const string FilePath = "tasks.json";
        private List<TaskModel> _tasks;

        public TaskService()
        {
            _tasks = LoadTasks();
        }

        private List<TaskModel> LoadTasks()
        {
            if (!File.Exists(FilePath))
            {
                return new List<TaskModel>();
            }

            var json = File.ReadAllText(FilePath);
            return string.IsNullOrEmpty(json)
                ? new List<TaskModel>()
                : JsonSerializer.Deserialize<List<TaskModel>>(json) ?? new List<TaskModel>();
        }

        private void SaveTasks()
        {
            var json = JsonSerializer.Serialize(_tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        private int GetNextId()
        {
            return _tasks.Count == 0 ? 1 : _tasks.Max(t => t.Id) + 1;
        }

        public List<TaskModel> GetAllTasks()
        {
            return _tasks;
        }

        public TaskModel? GetTaskById(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        public TaskModel CreateTask(TaskModel task)
        {
            task.Id = GetNextId();
            _tasks.Add(task);
            SaveTasks();
            return task;
        }

        public TaskModel? UpdateTask(int id, TaskModel task)
        {
            var existingTask = GetTaskById(id);
            if (existingTask == null)
                return null;

            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.Priority = task.Priority;
            existingTask.Status = task.Status;

            SaveTasks();
            return existingTask;
        }

        public bool DeleteTask(int id)
        {
            var task = GetTaskById(id);
            if (task == null)
                return false;

            _tasks.Remove(task);
            SaveTasks();
            return true;
        }
    }
}
