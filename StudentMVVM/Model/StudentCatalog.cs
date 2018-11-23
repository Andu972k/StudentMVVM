using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentMVVM.Exceptions;

namespace StudentMVVM.Model
{
    sealed class StudentCatalog
    {
        private ObservableCollection<Student> _students;
        private static StudentCatalog _instance;



        private StudentCatalog()
        {
            _students = new ObservableCollection<Student>();
            _students.Add(new Student(1, "Anders", 1997, "Kongevej 64", "Anders@gmail.com"));
            _students.Add(new Student(2, "Nikolai", 1995, "Kongevej 77", "Nikolai@gmail.com"));
            _students.Add(new Student(3, "Nathan", 1998, "Kongevej 100", "Nathan@gmail.com"));
            

        }


        public ObservableCollection<Student> Students
        {
            get
            {
                //if (_students is null)
                //{
                //    _students = new ObservableCollection<Student>();
                //}
                return _students;
            }
        }

        public static StudentCatalog Instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = new StudentCatalog();
                }

                return _instance;
            }
        }


        public static bool CheckStudentNo(int no)
        {
            //loop throw exception
            /*
             * if (StudentCatalog.Instance.Students.Count > 3)
            {
                foreach (Student s in StudentCatalog.Instance.Students)
                {
                    if (s.Number == _number)
                    {
                        throw new StudentNumberAlreadyExcistsException("This student Number already excists");
                    }
                }
            }
             */

            foreach (Student student in _instance.Students)
            {
                if (student.Number == no)
                {
                    throw new StudentNumberAlreadyExcistsException("This student Number already excists, Please select a new number");
                }
            }

            return true;
        }







    }
}
