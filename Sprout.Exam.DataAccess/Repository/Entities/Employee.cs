using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.DataAccess.Repository.Entities
{
    public class Employee: ExtendedEntity<int>
    {
        
      public string FullName { get; set; }
      public DateTime? Birthdate { get; set; }
      public string TIN { get; set; }
      public int EmployeeTypeId { get; set; }
      public float Salary { get; set; }
      public bool IsDeleted { get; set; }
}
}
