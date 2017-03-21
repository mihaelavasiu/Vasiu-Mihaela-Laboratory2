using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{

    public interface IDBManager
    {
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(Student student);
        Student SelectStudent(Student student);
        void AddCourse(Course course);
        void UpdateCourse(Course student);
        void DeleteCourse(Course student);
        void Enroll(int student_id, int course_id);
    }
}
