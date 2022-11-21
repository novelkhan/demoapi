using System.ComponentModel.DataAnnotations;

namespace demoapi.Models
{
    public class EmployeeModel
    {
        [Key]
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
    }
}
