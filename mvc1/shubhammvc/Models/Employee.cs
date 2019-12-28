using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shubhammvc.Models
{
    public class Employee
    {
        [Key]
        public int EmpNo { get; set; }
        public decimal Basic { get; set; }
        public string Name { get; set; }
        public int DeptNo { get; set; }
    }
}