using System.ComponentModel.DataAnnotations;

namespace WebAPIDemo.Data
{
    public class EmployeeDTO
    {
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        public int Age { get; set; }

        [MaxLength(10)]
        public string PhoneNumber { get; set; }

        public int Salary { get; set; }
    }
}
