using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiForeignKeys.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        [ForeignKey("TypeOne")]
        public int? EmployeeTypeIdOne { get; set; }
        [ForeignKey("TypeTwo")]
        public int? EmployeeTypeIdTwo { get; set; }
        [ForeignKey("TypeThree")]
        public int? EmployeeTypeIdThree { get; set; }

        [ForeignKey("ForTypeOne")]
        public int? DesignationIdOne { get; set; }
        [ForeignKey("ForTypeTwo")]
        public int? DesignationIdTwo { get; set; }
        [ForeignKey("ForTypeThree")]
        public int? DesignationIdThree { get; set; }

        public EmployeeType TypeOne { get; set; }
        public EmployeeType TypeTwo { get; set; }
        public EmployeeType TypeThree { get; set; }

        public Designations ForTypeOne { get; set; }
        public Designations ForTypeTwo { get; set; }
        public Designations ForTypeThree { get; set; }
    }
}
