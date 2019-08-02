using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab4_cs
{
    class StudentEnumerator : System.Collections.IEnumerator
    {
        public string[] et;
        int position = -1;
        public StudentEnumerator(string[] s1, string[] s2)
        {
            var both = s1.Intersect(s2);
            et = both.ToArray();
        }
        public bool MoveNext()
        {
            position++;
            return (position < et.Length);
        }
        public void Reset()
        {
            position = -1;
        }
        object System.Collections.IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public string Current
        {
            get
            {
                try
                {
                    return et[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
