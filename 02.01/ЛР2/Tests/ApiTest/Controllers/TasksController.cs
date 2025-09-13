using Microsoft.AspNetCore.Mvc;
using MyLibrary.Models;
using MyLibrary.Services;

namespace ApiTest.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public ActionResult<List<TaskModel>> GetAllTasks()
        {
            return _taskService.GetAllTasks();
        }

        [HttpGet("{id}")]
        public ActionResult<TaskModel> GetTask(int id)
        {
            var task = _taskService.GetTaskById(id);
            if (task == null)
                return NotFound("Задача не найдена.");

            return task;
        }

        [HttpPost]
        public ActionResult<TaskModel> CreateTask([FromBody] TaskModel task)
        {
            if (string.IsNullOrEmpty(task.Title) || string.IsNullOrEmpty(task.Description))
                return BadRequest("Название и описание обязательны для заполнения");

            if (task.Priority < 0 || task.Priority > 2)
                return BadRequest("Приоритет может быть 0, 1 или 2");

            var createdTask = _taskService.CreateTask(task);
            return CreatedAtAction(nameof(GetTask), new { id = createdTask.Id }, createdTask);
        }

        [HttpPut("{id}")]
        public ActionResult<TaskModel> UpdateTask(int id, [FromBody] TaskModel task)
        {
            if (task.Priority < 0 || task.Priority > 2)
                return BadRequest("Приоритет может быть 0, 1 или 2");

            var updatedTask = _taskService.UpdateTask(id, task);
            if (updatedTask == null)
                return NotFound("Задача не найдена.");

            return updatedTask;
        }

        // DELETE /tasks/{id} - удалить задачу
        [HttpDelete("{id}")]
        public ActionResult DeleteTask(int id)
        {
            var result = _taskService.DeleteTask(id);
            if (!result)
                return NotFound("Задача не найдена.");

            return NoContent();
        }
    }
}
