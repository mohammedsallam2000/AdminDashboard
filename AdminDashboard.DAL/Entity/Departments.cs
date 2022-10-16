using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminDashboard.DAL.Entity
{
   public class Departments
    {
        public int Id { get; set; }
        [StringLength(50)] // Constrain
        [Required]
        public string Name { get; set; }
        [StringLength(50)] // Constrain
        public string Code { get; set; }
    }
}
