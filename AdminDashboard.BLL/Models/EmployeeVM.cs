using AdminDashboard.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminDashboard.BLL.Models
{
    public class EmployeeVM
    {
        public EmployeeVM()
        {
            CreationDate = DateTime.Now;
            IsDeleted = false;
            IsActive = true;
        }
        public int Id { get; set; }
        [MinLength(3,ErrorMessage ="Min lengh 3")] // Constrain
        [MaxLength(50, ErrorMessage = "Max lengh 50")]
        [Required(ErrorMessage ="Name is required !")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Salary is required !")]
        [Range(5000,20000,ErrorMessage ="Salary between 5k : 20k")]
        public double Salary { get; set; }
        [EmailAddress(ErrorMessage = "Mail invalid")]
        public string Email { get; set; }
      //  [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
        public DateTime CreationDate { get; set; }
        //11StreetName-CityName-CountryName
        [RegularExpression("[0-9]{1,10}-[a-zA-Z]{1,50}-[a-zA-Z]{1,50}-[a-zA-Z]{1,50}", ErrorMessage = "Address Must Like : 12-StreetName-CityName-CountryName")]
        public string Address { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Department is required please choose department !")]
        public int DepartmentId { get; set; }
        // Navigation property
        [ForeignKey("DepartmentId")]
        public Departments Departments { get; set; }
    }
}
