using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StudentInfo
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        
        public Department Department { get; set; }

        public ICollection<StudentCourses> StudentCourses { get; set; }
    }
}
