using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public partial class User
{
    public int Id { get; set; }

    [Display(Name = "Роль")]
    public string Role { get; set; } = null!;

    [Display(Name = "ФИО")]
    public string FullName { get; set; } = null!;

    [Display(Name ="Логин")]
    public string Login { get; set; } = null!;

    [Display(Name = "Пароль")]
    public string Password { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
