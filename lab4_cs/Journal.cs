using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab4_cs
{
    class Journal
    {
        private List<JournalEntry> Entry = new List<JournalEntry>();
        public void StudentsCountChanged(object source, StudentListHandlerEventArgs args)
        {
            Entry.Add(new JournalEntry(args.CollectionName, args.ChangesType, args.ChangedObj));
        }
        public void StudentReferenceChanged(object source, StudentListHandlerEventArgs args)
        {
            Entry.Add(new JournalEntry(args.CollectionName, args.ChangesType, args.ChangedObj));
        }
        public override string ToString()
        {
            string str = "";
            foreach (JournalEntry j in Entry)
            {
                str += "Событие: " + j.ToString() + "\n";
            }
            return str;
        }
    }
}
