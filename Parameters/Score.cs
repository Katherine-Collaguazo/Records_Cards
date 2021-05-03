using System;
using System.Collections.Generic;
using System.Text;

namespace RecordLibrary
{
    public class Score
    {
        private int qualification;
        public int Qualification
        {
            get { return qualification; }
            set { qualification = value; }
        }
        private Parameters.Conduct conducts;
        public Parameters.Conduct Conduct
        {
            get { return conducts; }
            set { conducts = value; }
        }
    }
}
