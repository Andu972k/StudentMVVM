using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StudentMVVM.Annotations;
using StudentMVVM.Common;
using StudentMVVM.Model;

namespace StudentMVVM.ViewModel
{
    class StudentCatalogViewModel : INotifyPropertyChanged
    {

        #region Instance Fields


        private ObservableCollection<Student> _listOfStudents = StudentCatalog.Instance.Students;
        private Student _selectedStudent;
        private int _selectedIndex;

        
        private ICommand _deleteCommand;
        private ICommand _updateCommand;


        #endregion


        #region Constructor

        public StudentCatalogViewModel()
        {
            
            _deleteCommand = new RelayCommand(RemoveAt);
            _updateCommand = new RelayCommand(Update);
            

        }

        #endregion


        #region Properties

        /// <summary>
        /// Returns a observablecollection of students.
        /// </summary>
        public ObservableCollection<Student> ListOfStudents
        {
            get { return _listOfStudents; }
        }

        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value; 
                OnPropertyChanged();
            }
        }


        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                _selectedIndex = value;
                OnPropertyChanged();
            }
        }

       

        public ICommand DeleteCommand
        {
            get { return _deleteCommand; }
            set { _deleteCommand = value; }
        }

        public ICommand UpdateCommand
        {
            get { return _updateCommand; }
            set { _updateCommand = value; }
        }


        #endregion


        #region Methods


        

        public void RemoveAt()
        {
            _listOfStudents.RemoveAt(SelectedIndex);
        }

        public void Update()
        {
            int index = SelectedIndex;
            Student studentToUpdate = new Student(SelectedStudent.Number, SelectedStudent.Name, SelectedStudent.YearOfBirth, SelectedStudent.Address, SelectedStudent.Email);

            //ListOfStudents[index] = studentToUpdate;
            ListOfStudents.RemoveAt(index);
            ListOfStudents.Insert(index, studentToUpdate);


        }

        public bool StudentIsSelected()
        {
            if (SelectedStudent is null)
            {
                return true;
            }

            return false;
        }






        /// <summary>
        /// Notifies a binded GUI element that a property has changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            #endregion



        }
    }
}
