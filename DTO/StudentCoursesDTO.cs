using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class StudentCoursesDTO
    {
        public int Id { get; set; }
        public int StudentInfoId { get; set; }
        public int CourseId { get; set; }
        public int GradeId { get; set; }// From Generic Look up
        
    }
}
