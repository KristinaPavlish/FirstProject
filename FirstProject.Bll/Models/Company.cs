using System.ComponentModel.DataAnnotations;

namespace FirstProject.Bll.Models;
public class Company
{
    public List<Employee> Employees { get; set; }
    [Required]
    public string Name { get; set; }
    
}