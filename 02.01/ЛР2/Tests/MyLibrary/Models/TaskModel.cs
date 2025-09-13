namespace MyLibrary.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Priority { get; set; } // 0 - низкий, 1 - средний, 2 - высокий
        public bool Status { get; set; } // false - не выполнена, true - выполнена
    }
}
