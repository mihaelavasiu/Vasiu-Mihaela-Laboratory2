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
    }
}
