using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace employeedepartment.Models
{
    public class employee
    {
        // Pk
        public int Id { get; set; }
        public String EmployeeName { get; set; }
        public String Email { get; set; }
        public String City { get; set; }
        public DateTime RegisterDate { get; set; }

        //Relation 
        public int departmentId { get; set; }
        public department department { get; set; }
    }
}
