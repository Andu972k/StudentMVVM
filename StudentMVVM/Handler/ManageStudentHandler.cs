using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StudentMVVM.Common;
using StudentMVVM.Exceptions;
using StudentMVVM.Model;
using StudentMVVM.ViewModel;

namespace StudentMVVM.Handler
{
    class ManageStudentHandler
    {
        
        

        public StudentCatalogViewModel StudentCatalogViewModel { get; set; }

        public CreateStudentViewModel CreateStudentViewModel { get; set; }

       

        


        public ManageStudentHandler(StudentCatalogViewModel studentCatalogVM)
        {
            StudentCatalogViewModel = studentCatalogVM;
            studentCatalogVM.DeleteCommand = new RelayCommand(RemoveAt, StudentCatalogViewModel.StudentIsSelected);
            studentCatalogVM.UpdateCommand = new RelayCommand(Update, StudentCatalogViewModel.StudentIsSelected);
            
        }

        public ManageStudentHandler(CreateStudentViewModel createStudentViewModel)
        {
            CreateStudentViewModel = createStudentViewModel;
            createStudentViewModel.AddCommand = new RelayCommand(Add);

        }

        



        public void RemoveAt()
        {
            StudentCatalogViewModel.ListOfStudents.RemoveAt(StudentCatalogViewModel.SelectedIndex);
        }

        public void Update()
        {
            int index = StudentCatalogViewModel.SelectedIndex;
            try
            {
                Student studentToUpdate = new Student(StudentCatalogViewModel.SelectedStudent.Number, StudentCatalogViewModel.SelectedStudent.Name, 
                    StudentCatalogViewModel.SelectedStudent.YearOfBirth, StudentCatalogViewModel.SelectedStudent.Address, StudentCatalogViewModel.SelectedStudent.Email);

                StudentCatalogViewModel.ListOfStudents.RemoveAt(index);
                StudentCatalogViewModel.ListOfStudents.Insert(index, studentToUpdate);
            }
            catch (YearOfBirthTooLowException e)
            {
                MessageDialogHelper.Show(e.Message, "Invalid Year of birth");
            }
            catch (YearOfBirthIsTooHighException e)
            {
                MessageDialogHelper.Show(e.Message, "Invalid Year of birth");
            }
            catch (StudentNumberAlreadyExcistsException e)
            {
                MessageDialogHelper.Show(e.Message, "Student number is taken");
            }
            catch (EmailDoesNotContainQuickAException e)
            {
                MessageDialogHelper.Show(e.Message, "Invalid email");
            }


            //ListOfStudents[index] = studentToUpdate;



        }

        public void Add()
        {
            try
            {
                StudentCatalog.CheckStudentNo(CreateStudentViewModel.NewStudent.Number);
                CreateStudentViewModel.ListOfStudents.Add(new Student(CreateStudentViewModel.NewStudent.Number,
                    CreateStudentViewModel.NewStudent.Name,
                    CreateStudentViewModel.NewStudent.YearOfBirth, CreateStudentViewModel.NewStudent.Address,
                    CreateStudentViewModel.NewStudent.Email));
            }
            catch (YearOfBirthTooLowException e)
            {
                MessageDialogHelper.Show(e.Message, "Invalid Year of birth");
            }
            catch (YearOfBirthIsTooHighException e)
            {
                MessageDialogHelper.Show(e.Message, "Invalid Year of birth");
            }
            catch (StudentNumberAlreadyExcistsException e)
            {
                MessageDialogHelper.Show(e.Message, "Student number is taken");
            }
            catch (EmailDoesNotContainQuickAException e)
            {
                MessageDialogHelper.Show(e.Message, "Invalid email");
            }
            
        }

    }
}
