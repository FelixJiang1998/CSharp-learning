using System.ComponentModel.DataAnnotations;

namespace FilterDemo.API.Models;

public class User
{
    public int Id { get; set; }
    [Required] public string Username { get; set; }
}