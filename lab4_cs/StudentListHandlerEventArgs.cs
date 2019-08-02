using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab4_cs
{
    delegate void StudentListHandler(object source, StudentListHandlerEventArgs args);
    class StudentListHandlerEventArgs: System.EventArgs
    {
        public string CollectionName { get; set; }
        public string ChangesType { get; set; }
        public Student ChangedObj { get; set; }
        public StudentListHandlerEventArgs(string name, string type, Student obj)
        {
            CollectionName = name;
            ChangesType = type;
            ChangedObj = obj;
        }
        public StudentListHandlerEventArgs()
        {
            CollectionName = "null";
            ChangesType = "null";
            ChangedObj = new Student();
        }
        public override string ToString()
        {
            return CollectionName + " " + ChangesType + " " + ChangedObj.ToString();
        }
    }
}
