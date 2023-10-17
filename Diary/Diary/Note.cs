using System;
using System.Collections.Generic;

namespace Diary
{
    internal class Note
    {


        public DateTime Day_received;
        public DateTime day;
        private Dictionary<DateTime, List<(string Title, string Description)>> Day_note = new Dictionary<DateTime, List<(string Title, string Description)>>();

     

        public void AddNoteForDay(string title, string Description, DateTime day)
        {

                if (!Day_note.ContainsKey(day))
                {
                    Day_note[day] = new List<(string title, string Description)>();
                }

                if (Day_note[day].Count < 5)
                {
                    Day_note[day].Add((title, Description));    
                }

            

        }

        
        public  List<(string title, string Description)> GetNotesForDay(DateTime day)
        {
            if (Day_note.ContainsKey(day))
            {
                return Day_note[day];   
            }
           return new List<(string title, string Description)>();
        }
    }
}
