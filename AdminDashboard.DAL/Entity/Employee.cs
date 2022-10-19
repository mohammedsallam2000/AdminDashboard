using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminDashboard.DAL.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        [StringLength(50)] // Constrain
        [Required]
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

        public int DepartmentId { get; set; }
        // Navigation property
        [ForeignKey("DepartmentId")]
        public Departments Departments { get; set; }

    }
}
