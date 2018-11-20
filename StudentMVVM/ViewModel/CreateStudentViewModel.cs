using System.Collections.ObjectModel;
using System.Windows.Input;
using StudentMVVM.Common;
using StudentMVVM.Model;

namespace StudentMVVM.ViewModel
{
    class CreateStudentViewModel
    {


        #region Instance Fields

        private ObservableCollection<Student> _listOfStudents = StudentCatalog.Instance.Students;
        private Student _newStudent;

        private ICommand _addCommand;



        #endregion



        #region Property

        public ObservableCollection<Student> ListOfStudents
        {
            get { return _listOfStudents; }
            
        }

        public Student NewStudent
        {
            get { return _newStudent; }
            set { _newStudent = value; }
        }

        public ICommand AddCommand
        {
            get { return _addCommand; }
            set { _addCommand = value; }
        }


        #endregion

        #region Constructor

        public CreateStudentViewModel()
        {
            _addCommand = new RelayCommand(Add);
        }


        #endregion


        #region Methods
        public void Add()
        {

        }


        #endregion





    }
}
