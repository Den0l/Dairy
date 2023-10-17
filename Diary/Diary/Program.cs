
namespace Diary
{
    using System;
    using System.Globalization;

    internal class Program
    {
        static DateTime ChangeDate(ConsoleKeyInfo key, DateTime day) 
        {

            if (key.Key == ConsoleKey.RightArrow)
            {
                    
                day = day.AddDays(1);
                return day;

            }
            else if (key.Key == ConsoleKey.LeftArrow)
            {
                day = day.AddDays(-1);
                return day;
            }
            else
            {
                return day;
            }

        }

        static void ShowNoteDescription((string Title, string Description) note)
        {
            Console.Clear();
            Console.WriteLine("Заголовок: " + note.Title);
            Console.WriteLine("Описание: " + note.Description);
            Console.WriteLine("Нажмите любую клавишу, чтобы вернуться...");
            Console.ReadKey();
            
        }
        
        static void Main()
        {
            var day = DateTime.Now;
            Note notice = new Note();
            int pos = 1;
            List<int> notePos = new List<int>();
            ConsoleKeyInfo key;
            List<string> Note_Dis = new List<string>();
            notice.Day_received = day;

           
            DateTime date1 = new DateTime(2023, 10, 15);
            notice.AddNoteForDay("Заметка 1", "Описание 1", date1);

            DateTime date2 = new DateTime(2023, 10, 17);
            notice.AddNoteForDay("Заметка 2", "Описание 2", date2);
            

            DateTime date3 = new DateTime(2023, 10, 20);
            notice.AddNoteForDay("Заметка 3", "Описание 3", date3);
            

            DateTime date4 = new DateTime(2023, 10, 10);
            notice.AddNoteForDay("Заметка 4", "Описание 4", date4);

            DateTime date5 = new DateTime(2023, 10, 13);
            notice.AddNoteForDay("Заметка 5", "Описание 5", date5);

            do
            {
                Console.WriteLine("Дата: " + day.ToString("d"));


                List<(string title, string Description)> notesForDay = notice.GetNotesForDay(day);
                List<(string title, string Description)> notes1 = notice.GetNotesForDay(date1);
                List<(string title, string Description)> notes2 = notice.GetNotesForDay(date2);
                List<(string title, string Description)> notes3 = notice.GetNotesForDay(date3);
                List<(string title, string Description)> notes4 = notice.GetNotesForDay(date4);
                List<(string title, string Description)> notes5 = notice.GetNotesForDay(date5);
                pos = 1;
                
                if (day.Date == date1.Date)
                {
                    foreach (var (title, _) in notes1)
                    {
                        Console.SetCursorPosition(2, pos);
                        Console.Write(pos + ". " + title);
                        if (pos >= 5) { pos = 1; }
                        else { pos++; }
                    }

                }
                else if (day.Date == date2.Date)
                {
                    foreach (var (title, _) in notes2)
                    {
                        Console.SetCursorPosition(2, pos);
                        Console.Write(pos + ". " + title);
                        if (pos >= 5) { pos = 1; }
                        else { pos++; }
                    }

                }
                else if (day.Date == date3.Date)
                {
                    foreach (var (title, _) in notes3)
                    {
                        Console.SetCursorPosition(2, pos);
                        Console.Write(pos + ". " + title);
                        if (pos >= 5) { pos = 1; }
                        else { pos++; }
                    }
                }
                else if (day.Date == date4.Date)
                {
                    foreach (var (title, _) in notes4)
                    {
                        Console.SetCursorPosition(2, pos);
                        Console.Write(pos + ". " + title);
                        if (pos >= 5) { pos = 1; }
                        else { pos++; }
                    }
                }
                else if (day.Date == date5.Date)
                {
                    foreach (var (title, _) in notes5)
                    {
                        Console.SetCursorPosition(2, pos);
                        Console.Write(pos + ". " + title);
                        if (pos >= 5) { pos = 1; }
                        else { pos++; }
                    }
                }

                foreach (var (title, _) in notesForDay)
                    {
                        Console.SetCursorPosition(2, pos);
                        Console.Write(pos + ". " + title);
                        if (pos >= 5) { pos = 1; }
                        else { pos++; }
                    }


                Console.SetCursorPosition(0, 0);
                key = Console.ReadKey();



                if (key.Key == ConsoleKey.RightArrow)
                {
                    Console.Clear();
                    day = ChangeDate(key, day);
                    notice.Day_received = day;
                    pos = 1;


                }
                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    Console.Clear();
                    day = ChangeDate(key, day);
                    notice.Day_received = day;
                    pos = 1;

                }



                if (key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.UpArrow)
                {
                    pos = 1;
                    Console.SetCursorPosition(0, pos); 
                    Console.Write("->");
                    do
                    {
                        Console.SetCursorPosition(0, pos);
                        key = Console.ReadKey();
                        Console.WriteLine("  ");

                        if (key.Key == ConsoleKey.UpArrow)
                        {
                            pos--;
                            if (pos <= 0)
                            {
                                pos = 5;
                            }
                        }
                        else if (key.Key == ConsoleKey.DownArrow)
                        {
                            pos++;
                            if (pos > 5)
                            {
                                pos = 1;
                            }
                        }

                        Console.SetCursorPosition(0, pos);
                        Console.Write("->");

                       if(key.Key == ConsoleKey.RightArrow)
                       {
                            
                           
                            Console.SetCursorPosition(4, pos);
                            string title = Console.ReadLine();
                            Console.SetCursorPosition(4, pos+1);
                            string des = Console.ReadLine();
                            Note_Dis.Add(des);
                            notice.AddNoteForDay(title, des, day);

                        }
                       else if (key.Key == ConsoleKey.Enter)
                       {
                            if (notesForDay.Count > 0)
                            {

                                ShowNoteDescription(notesForDay[pos - 1]);
                                break;
                            }
                        }


                    } while (key.Key != ConsoleKey.Spacebar);
                    

                    Console.Clear();
                    
                }

                Console.Clear();
                
            } while (key.Key != ConsoleKey.Escape);
        }
    }
}