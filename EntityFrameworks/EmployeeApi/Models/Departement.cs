using System.Text.Json.Serialization;
using EmployeeApi.Models;

namespace EmployeeApi.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public List<Employee> Employees { get; set; } = new();
    }

}