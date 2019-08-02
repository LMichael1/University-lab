using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab4_cs
{
    class TestCollections
    {
        private List<Person> personlist = new List<Person>();
        private List<string> str = new List<string>();
        private Dictionary<Person, Student> dict1 = new Dictionary<Person, Student>();
        private Dictionary<string, Student> dict2 = new Dictionary<string, Student>();
        public Student Gen(int a)
        {
            Student st = new Student();
            st.FirstName += string.Format(" #{0}", a);
            return st;
        }
        public TestCollections (int n)
        {
            for (int i=0; i<n; i++)
            {
                Student tmp = Gen(i);
                personlist.Add(tmp.Stud);
                str.Add(tmp.Stud.ToString());
                dict1.Add(tmp.Stud, tmp);
                dict2.Add(tmp.Stud.ToString(), tmp);
            }
        }
        public void SearchTime(int a)
        {
            Person p1 = new Person();
            Student s1 = new Student();
            switch (a)
            {
                case 1:
                    {
                        p1.FirstName += string.Format(" #1");
                        break;
                    }
                case 2:
                    {
                        p1.FirstName += string.Format(" #{0}", personlist.Count-1);
                        break;
                    }
                case 3:
                    {
                        p1.FirstName += string.Format(" #{0}", (personlist.Count - 1)/2);
                        break;
                    }
                case 4:
                    {
                        p1.FirstName += string.Format(" #{0}", personlist.Count);
                        break;
                    }
            }
            s1.Stud = p1;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            bool b = personlist.Contains(p1);
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            Console.WriteLine(b);
            sw.Restart();
            b = str.Contains(p1.ToString());
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            Console.WriteLine(b);
            sw.Restart();
            dict1.ContainsKey(p1);
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            Console.WriteLine(b);
            sw.Restart();
            dict2.ContainsKey(p1.ToString());
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            Console.WriteLine(b);
            sw.Restart();
            dict1.ContainsValue(s1);
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            Console.WriteLine(b); 
        }
    }
}
