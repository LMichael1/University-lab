using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab4_cs
{
    class Student : Person, IDateAndCopy, System.Collections.IEnumerable
    {
        private Education edu;
        private int num;
        private System.Collections.Generic.List<Test> tests;
        private System.Collections.Generic.List<Exam> exams;
        public Education Edu
        {
            get { return edu; }
            set { edu = value; }
        }
        public int Num
        {
            get { return num; }
            set
            {
                if (value >= 1 && value <= 100) num = value;
                else { throw new ArgumentOutOfRangeException("Значение должно быть в диапазоне от 1 до 100."); }
            }
        }
        public Person Stud
        {
            get
            {
                Person st = new Person(base.FirstName, base.LastName, base.Date);
                return st;
            }
            set
            {
                FirstName = value.FirstName;
                LastName = value.LastName;
                Date = value.Date;
            }
        }
        public System.Collections.Generic.List<Exam> Exams
        {
            get { return exams; }
            set { exams = value; }
        }
        public System.Collections.Generic.List<Test> Tests
        {
            get { return tests; }
            set { tests = value; }
        }
        public Student(Person stud, Education edu, int num) : base(stud.FirstName, stud.LastName, stud.Date)
        {
            Edu = edu;
            Num = num;
            Exams = new List<Exam>();
            Tests = new List<Test>();
        }
        public Student()
        {
            Edu = Education.Bachelor;
            Num = 1;
            Exams = new List<Exam>();
            Tests = new List<Test>();
        }
        public double Average
        {
            get
            {
                double aver = 0;
                foreach (var exam in Exams)
                {
                    aver += exam.Mark;
                }
                if (Exams.Count > 0)
                {
                    return aver / Exams.Count;
                }
                else return 0;
            }
        }
        public void AddExams(params Exam[] ex)
        {
            for (int i = 0; i < ex.Length; i++)
            {
                Exams.Add(ex[i]);
            }
        }
        public override string ToString()
        {
            string a = "";
            string b = "";
            foreach (var exam in Exams)
            {
                a += exam.ToString();
            }
            foreach (var test in Tests)
            {
                b += test.ToString();
            }
            return "Студент:\n" + base.ToString() + "Образование: " + edu.ToString() + " Номер: " + num + "\nЭкзамены:\n" + a + "\nТесты\n" + b + "\n";
        }
        public new string ToShortString()
        {
            return "Студент:\n" + base.ToString() + "Образование: " + edu.ToString() + " Номер: " + num + " Число зачетов: " + Tests.Count + " Число экзаменов: " + Exams.Count + " Средний балл: " + Average + "\n";
        }
        public override object DeepCopy()
        {
            Student obj = new Student(this.Stud, this.Edu, this.Num);
            for (int i = 0; i < Exams.Count; i++)
            {
                obj.Exams.Add((Exam)Exams[i].DeepCopy());
            }
            for (int i = 0; i < Tests.Count; i++)
            {
                obj.Tests.Add((Test)Tests[i].DeepCopy());
            }
            return obj;
        }
        public IEnumerable<object> ExamsAndTests()
        {
            foreach (var ex in Exams) { yield return ex; }
            foreach (var t in Tests) { yield return t; }
        }
        public IEnumerable<object> BMark(int a)
        {
            foreach (var ex in Exams)
            {
                if (ex.Mark > a)
                {
                    yield return ex;
                }
            }
        }
        public IEnumerable<object> PassedExamsAndTests()
        {
            foreach (var ex in Exams)
            {
                if (ex.Mark > 2)
                {
                    yield return ex;
                }
            }
            foreach (var t in Tests)
            {
                if (t.TestPass == true)
                {
                    yield return t;
                }
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return (System.Collections.IEnumerator)GetEnumerator();
        }
        public StudentEnumerator GetEnumerator()
        {
            string[] s1 = new string[Exams.Count];
            string[] s2 = new string[Tests.Count];
            for (int i = 0; i < Exams.Count; i++)
            {
                s1[i] = Exams[i].Subject;
            }
            for (int i = 0; i < Tests.Count; i++)
            {
                s2[i] = Tests[i].Subject;
            }
            return new StudentEnumerator(s1, s2);
        }
        public IEnumerable<object> PassedExamsAndTests2()
        {
            foreach (var t in Tests)
            {
                if (t.TestPass)
                {
                    foreach (var ex in Exams)
                    {
                        if (ex.Subject == t.Subject && ex.Mark > 2)
                        {
                            yield return t;
                        }
                    }
                }
            }
        }
    }
}
