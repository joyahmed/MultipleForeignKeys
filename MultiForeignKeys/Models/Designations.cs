using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiForeignKeys.Models
{
    public class Designations
    {
        [Key]
        public int DesignationId { get; set; }

        [Display(Name = "Employee Type")]
        public int EmployeeTypeId { get; set; }

        public string DesignationName { get; set; }

        public EmployeeType EmployeeType { get; set; }

        [InverseProperty("ForTypeOne")]
        public List<Employee> One { get; set; }

        [InverseProperty("ForTypeTwo")]
        public List<Employee> Two { get; set; }

        [InverseProperty("ForTypeThree")]
        public List<Employee> Three { get; set; }
    }
}
