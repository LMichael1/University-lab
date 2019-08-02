using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab4_cs
{
    class AverageComparer: IComparer<Student>
    {
        int IComparer<Student>.Compare(Student st1, Student st2)
        {
            if (st1 != null && st2 != null)
            {
                return st1.Average.CompareTo(st2.Average);
            }
            else throw new ArgumentException();
        }
    }
}
