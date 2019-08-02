using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab4_cs
{
    class Test
    {
        public string Subject { get; set; }
        public bool TestPass { get; set; }
        public Test(string subject, bool testpass)
        {
            Subject = subject;
            TestPass = testpass;
        }
        public Test()
        {
            Subject = "null";
            TestPass = false;
        }
        public override string ToString()
        {
            string str;
            if (TestPass == false)
            { str = "не сдан"; }
            else { str = "сдан"; }
            return string.Format("Предмет: {0}, {1}.\n", Subject, str);
        }
        public object DeepCopy()
        {
            Test obj = new Test(this.Subject, this.TestPass);
            return obj;
        }
    }
}
