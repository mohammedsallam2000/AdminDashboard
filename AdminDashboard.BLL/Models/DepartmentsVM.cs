using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminDashboard.BLL.Models
{
    public class DepartmentsVM
    {

        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter Department Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Department Code")]
        public string Code { get; set; }
    }
}
