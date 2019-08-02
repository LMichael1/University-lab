using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab4_cs
{
    interface IDateAndCopy
    {
        object DeepCopy();
        DateTime Date { get; set; }
    }
}
