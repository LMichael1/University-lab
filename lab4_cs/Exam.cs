using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab4_cs
{
    class Exam : IDateAndCopy
    {
        public string Subject { get; set; }
        public int Mark { get; set; }
        public DateTime Date { get; set; }
        public Exam(string subject, int mark, DateTime examdate)
        {
            Subject = subject;
            Mark = mark;
            Date = examdate;
        }
        public Exam()
        {
            Subject = "null";
            Mark = 0;
            Date = new DateTime(2000, 01, 01);
        }
        public override string ToString()
        {
            return "Предмет: " + Subject + " Оценка: " + Mark + " Дата: " + Date + "\n";
        }
        public object DeepCopy()
        {
            Exam obj = new Exam(this.Subject, this.Mark, this.Date);
            return obj;
        }
    }
}
