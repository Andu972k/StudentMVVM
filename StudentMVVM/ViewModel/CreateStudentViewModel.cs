using System.Collections.ObjectModel;
using System.Windows.Input;
using StudentMVVM.Common;
using StudentMVVM.Handler;
using StudentMVVM.Model;

namespace StudentMVVM.ViewModel
{
    class CreateStudentViewModel
    {


        #region Instance Fields

        private ObservableCollection<Student> _listOfStudents = StudentCatalog.Instance.Students;
        private Student _newStudent = new Student();


        private ICommand _addCommand;


        #endregion



        #region Property

        public ObservableCollection<Student> ListOfStudents
        {
            get { return _listOfStudents; }
            
        }

        public ICommand AddCommand
        {
            get { return _addCommand; }
            set { _addCommand = value; }
        }

        public Student NewStudent
        {
            get { return _newStudent; }
            set { _newStudent = value; }
        }

        public ManageStudentHandler ManageStudentHandler { get; set; }
        


        #endregion

        #region Constructor

        public CreateStudentViewModel()
        {
            ManageStudentHandler = new ManageStudentHandler(this);
        }


        #endregion


        #region Methods
        


        #endregion





    }
}
