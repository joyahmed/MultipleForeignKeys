using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiForeignKeys.Models
{
    public class EmployeeType
    {
        [Key]
        public int TypeId { get; set; }
        public string TypeName { get; set; }

        public List<Designations> Designations { get; set; }

        [InverseProperty("TypeOne")]
        public List<Employee> One { get; set; }

        [InverseProperty("TypeTwo")]
        public List<Employee> Two { get; set; }

        [InverseProperty("TypeThree")]
        public List<Employee> Three { get; set; }
    }
}
