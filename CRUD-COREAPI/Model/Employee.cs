using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_COREAPI.Model
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int    Empno { get; set; }
        public string Ename { get; set; }
        public string designation { get; set; }
        public int    mgr { get; set; }
      public DateTime hiredate { get; set; }
       public decimal sal { get; set; }
       public decimal comm { get; set; }
           public int dept { get; set; }
    }
}
