using System;
namespace RecordLibrary
{
    public class Studient
    {
        
        public Studient(string Namestudient, string Lastnamestudient, string Email, string Representative)
        {
            this.Namestudient = Namestudient;
            this.Lastnamestudient = Lastnamestudient;
            this.Email = Email;
            this.Representative = Representative;
        }


        private int studientCode;
        public int Studientcode
        {
            get { return studientCode; }
            set { studientCode = value; }
        }
        public int lista;
        public int Lista
        {
            get { return lista; }
            set { lista = value; }
        }
        private string nameStudient;
        public string Namestudient
        {
            get { return nameStudient; }
            set { nameStudient = value; }
        }
        private string lastnamestudient;
        public string Lastnamestudient
        {
            get { return lastnamestudient; }
            set { lastnamestudient = value; }
        }
        private int phoneStudient;
        public int Phonestudient
        {
            get { return phoneStudient; }
            set { phoneStudient = value; }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string representative;
        public string Representative
        {
            get { return representative; }
            set { representative = value; }
        }

    }
}
