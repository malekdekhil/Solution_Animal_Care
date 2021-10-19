using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalCare_Client.Pages.Models
{
    public class CalendarModel: ICalendarModel
    {
 
        public int IdCalendar { get; set; }
        public bool isCurrentDay { get; set; }
        public int currentMonth { get; set; }

        public int currentYear { get; set; }
        public int DaysInMonth { get; set; }
         public Dictionary<int, string> DictionaryMonth { get; set; }

   
        public CalendarModel()
        {
             DictionaryMonth = new Dictionary<int, string>();
         }


        public Dictionary<int, string> GetDictionaryMonth()
        {
            Dictionary<int, string> months = new Dictionary<int, string>();
            months.Add(1, "Janvier");
            months.Add(2, "Février");
            months.Add(3, "Mars");
            months.Add(4, "Avril");
            months.Add(5, "Mai");
            months.Add(6, "Juin");
            months.Add(7, "Juillet");
            months.Add(8, "Août");
            months.Add(9, "Septembre");
            months.Add(10, "Octobre");
            months.Add(11, "Novembre");
            months.Add(12, "Décembre");
            return months;
        }
    public DateTime GetStartDate(int year, int month, out int Day)
    {
            Day = 1;
         return new DateTime(year, month, Day);
    }
        public int GetNumberDaysInMonth(int year, int month)
        {
            return DateTime.DaysInMonth(year, month);
           

        }
        public void NextMonth()
        {
 

            currentMonth++;
                DaysInMonth = 7;
           
                if (currentMonth > 12)
                {
                    currentMonth = 1;
                    DictionaryMonth.Select(a => a.Key == 1);
                    currentYear++;
                }
               
            

            

        }
        public void PrevMonth()
        {
 


            currentMonth--;
                if (currentMonth == DateTime.Now.Month && currentYear == DateTime.Now.Year)
                {
                    DaysInMonth = DateTime.DaysInMonth(currentYear, currentMonth);
                    if (currentMonth < 1)
                    {
                        currentMonth = 12;
                        DictionaryMonth.Select(a => a.Key == 12);
                        currentYear--;
                    }

                }
                else
                {
                    DaysInMonth = 7;

                    if (currentMonth < 1)
                    {
                        currentMonth = 12;
                        DictionaryMonth.Select(a => a.Key == 12);
                        currentYear--;
                    }
                }
           
          
          
             
          

 
        }
        public void NextWeek()
        {

             DaysInMonth = DaysInMonth + 7;

                var curentDaysInMonth = DateTime.DaysInMonth(currentYear, currentMonth);
 
             if (DaysInMonth > curentDaysInMonth)
                {
                    DaysInMonth = curentDaysInMonth;

                }
           



        }
        public void PrevWeekInNextMonth()
        {

                DaysInMonth = DaysInMonth - 7;


                if (DaysInMonth < 7)
                {
                    DaysInMonth = 7;

                }
            



        }
        public void PrevWeekInCurrentMonth()
        {

            DaysInMonth = DateTime.DaysInMonth(currentYear, currentMonth) ;
        }
        public int intervalLastDayAndFirstDay(int year, int currentMonth)
        {
            DateTime current = new DateTime(year, currentMonth, 1);

            var y = current.Date.ToString("dddd");
            int result = 0;
            if (y == "lundi")
            {
                result = 0;
            }
            else if (y == "mardi")
            {
                result = 1;
            }
            else if (y == "mercredi")
            {
                result = 2;
            }
            else if (y == "jeudi")
            {
                result = 3;
            }
            else if (y == "vendredi")
            {
                result = 4;
            }
            else if (y == "samedi")
            {
                result = 5;
            }
            else if (y == "dimanche")
            {
                result = 6;
            }
            return result;
        }
       

    }
    public interface ICalendarModel
    {
         public Dictionary<int, string> GetDictionaryMonth();
        public DateTime GetStartDate(int year, int month, out int Day);
        public int GetNumberDaysInMonth(int year, int month);
        public void NextMonth();
        public void PrevMonth();
        public void NextWeek();
        public void PrevWeekInCurrentMonth();
        public void PrevWeekInNextMonth();

        public int intervalLastDayAndFirstDay(int year, int currentMonth);
 




    }
}
