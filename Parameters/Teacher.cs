using System;
using System.Collections.Generic;
using System.Text;

namespace RecordLibrary
{
    public class Teacher
    {
        private string nameTeacher;
        public string Nameteacher
        {
            get { return nameTeacher; }
            set { nameTeacher = value; }
        }
        private int phoneTeacher;
        public int Phoneteacher
        {
            get { return phoneTeacher; }
            set { phoneTeacher = value; }
        }
    }
}
