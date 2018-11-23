using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentMVVM.Exceptions;

namespace StudentMVVM.Model
{
    class Student
    {

        #region Instance Fields

        private int _number;
        private string _name;
        private int _yearOfBirth;
        private string _address;
        private string _email;
        private string _imageSource = @"C:\EASJ\SWC\Programmer\Sesion 21\StudentMVVM\StudentMVVM\StudentMVVM\Assets\Wide310x150Logo.scale-200.png";

        #endregion

        #region Properties

        /// <summary>
        /// Returns the number of a student object.
        /// </summary>
        /// <returns>int</returns>
        public int Number
        {
            get { return _number; }
            set { _number = value; }

        }

        /// <summary>
        /// Returns the name of a student.
        /// </summary>
        /// <returns>string</returns>

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Returns a students year of birth.
        /// </summary>
        /// <returns>string</returns>
        public int YearOfBirth
        {
            get { return _yearOfBirth; }
            set { _yearOfBirth = value; }
        }

        /// <summary>
        /// Returns the address of a student.
        /// </summary>
        /// <returns>string</returns>
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        /// <summary>
        /// Returns the email of a student.
        /// </summary>
        /// <returns>string</returns>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string ImageSource
        {
            get { return _imageSource; }
            
        }



        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a student object.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="name"></param>
        /// <param name="yearOfBirth"></param>
        /// <param name="address"></param>
        /// <param name="email"></param>
        public Student(int number, string name, int yearOfBirth, string address, string email)
        {
            
            _number = number;
            _name = name;
            _yearOfBirth = yearOfBirth;
            if (_yearOfBirth < 1990)
            {
                throw new YearOfBirthTooLowException("Year of birth too low, Please type a year from 1990-2018");
            }
            else if (_yearOfBirth > DateTime.Now.Year)
            {
                throw new YearOfBirthIsTooHighException($"Year of birth is too high, Please type a year from 1990-{DateTime.Now.Year}");
            }
            _address = address;
            _email = email;
            if (!email.Contains("@"))
            {
                throw new EmailDoesNotContainQuickAException("Email should contain a @");
            }

        }

        public Student()
        {

        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a string, which gives a description of a student object.
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            return $"Student number {_number} is named {_name} and is born in the year {_yearOfBirth}, {_name} lives at {_address}, and {_name}'s email is {_email}";
        }

        public override bool Equals(object obj)
        {
            if (Number == ((Student)obj).Number)
            {
                return true;
            }

            return false;
        }

        #endregion


    }
}
