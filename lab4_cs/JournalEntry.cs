using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab4_cs
{
    class JournalEntry
    {
        public string ColName { get; set; }
        public string ChangesType { get; set; }
        public Student Obj { get; set; }
        public JournalEntry(string col, string change, Student obj)
        {
            ColName = col;
            ChangesType = change;
            Obj = obj;
        }
        public override string ToString()
        {
            return ColName + ", " + ChangesType + "\n" + Obj.ToShortString();
        }
    }
}
