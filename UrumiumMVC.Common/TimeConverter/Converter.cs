using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.Common.TimeConverter
{
    public class Converter
    {
        public TimeSpan GetTimeTafazol(DateTime dt1,DateTime dt2)
        {
            return dt1 - dt2;
        }

        public int GetdayTafazol(DateTime dt1, DateTime dt2)
        {
            return GetTimeTafazol(dt1,dt2).Days;
        }

        public String GetPersianDate(DateTime dt)
        {
            PersianCalendar pc=new PersianCalendar();
            if (IsToday(dt))
            {
                return LimitedPersianDatetime(dt);
            }
            return PersianDays(pc.GetDayOfWeek(dt).ToString())+" "+ pc.GetDayOfMonth(dt).ToString() + " " + PersianMonth(pc.GetMonth(dt)) + " "+dt.Hour+":"+dt.Minute+":"+dt.Second;
        }

        public String GetPersianWeek(DateTime dt)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetDayOfWeek(dt).ToString();
        }

        public String GetCurrentDay(DateTime dt)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetDayOfWeek(dt).ToString();
        }

        public string PersianMonth(int month)
        {
            switch (month)
            {
                case 1:
                    return "فروردین";
                case 2:
                    return "اردیبهشت";
                case 3:
                    return "خرداد";
                case 4:
                    return "تیر";
                case 5:
                    return "مرداد";
                case 6:
                    return "شهریور";
                case 7:
                    return "مهر";
                case 8:
                    return "ابان";
                case 9:
                    return "آذر";
                case 10:
                    return "دی";
                case 11:
                    return "بهمن";
                case 12:
                    return "اسفند";
            }
            return "";
        }

        public string PersianDays(string day)
        {
            if (day!="")
            {
                if(day.Contains("Sa"))
                    return "شنبه";
                if (day.Contains("Su"))
                    return "یکشنبه";
                if (day.Contains("Mo"))
                    return "دوشنبه";
                if (day.Contains("Tue"))
                    return "سه شنبه";
                if (day.Contains("Wed"))
                    return "چهارشنبه";
                if (day.Contains("Thu"))
                    return "پنجشنبه";
                if (day.Contains("Fr"))
                    return "جمعه";
            }
            return "";
        }

        public Boolean IsToday(DateTime dt)
        {
            DateTime nowdt = DateTime.Now;
            if (nowdt.Year==dt.Year && nowdt.Month==dt.Month && nowdt.Day==dt.Day)
            {
                return true;
            }
            return false;
        }

        public string LimitedPersianDatetime(DateTime dt)
        {
            DateTime nowdt = DateTime.Now;
            if (nowdt.Hour-dt.Hour==0)
            {
                if (nowdt.Minute - dt.Minute == 0)
                {
                    return "دقایقی پیش";
                }
                else
                {
                    return (nowdt.Minute - dt.Minute).ToString()+ " دقیقه پیش";
                }
                
            }
            else
            {
                return (nowdt.Hour - dt.Hour).ToString() + " ساعت پیش";
            }
        }

        public string Changetoenglishchar(string s)
        {
            string result = "";
            foreach (var item in s)
            {
                if (item== '۰')
                {
                    result += '0';
                }
                else if (item == '۱')
                {
                    result += '1';
                }
                else if (item== '۲')
                {
                    result += '2';
                }
                else if (item == '۳')
                {
                    result += '3';
                }
                else if (item == '۴')
                {
                    result += '4';
                }
                else if (item == '۵')
                {
                    result += '5';
                }
                else if (item == '۶')
                {
                    result += '6';
                }
                else if (item == '۷')
                {
                    result += '7';
                }
                else if (item == '۸')
                {
                    result += '8';
                }
                else if (item == '۹')
                {
                    result += '9';
                }
                else if (item == '/')
                {
                    result += '/';
                }

            }
            return result;
        }
        public string ConvertToPersianCalenderDatetime(string dt)
        {
            string year = "";
            string mounth = "";
            string day = "";
            day = dt.Substring(0, 2);
            mounth = dt.Substring(3, 2);
            year = dt.Substring(6, 4);
            //DateTime myDate = DateTime.Parse(date);
            //DateTime dtd = new DateTime(Convert.ToInt32(year), Convert.ToInt32(mounth), Convert.ToInt32(day), new System.Globalization.PersianCalendar());
            //return dtd.ToString(CultureInfo.InvariantCulture);
            return year + "/" + mounth + "/" + day;
        }

        public DateTime ConvertToEnglishSearchDatetime(string dt)
        {
            string year = "";
            string mounth = "";
            string day = "";
            day = dt.Substring(0, 2);
            mounth = dt.Substring(3, 2);
            year = dt.Substring(6, 4);
            DateTime dtd;
            //DateTime myDate = DateTime.Parse(date);
            return dtd = new DateTime(Convert.ToInt32(year), Convert.ToInt32(mounth), Convert.ToInt32(day), new System.Globalization.PersianCalendar());
            
        }

        public DateTime ConvertToEnglishSearchDatetimeStartToFinish(string dt)
        {
            string year = "";
            string mounth = "";
            string day = "";
            year = dt.Substring(0, 4);
            mounth = dt.Substring(5, 2);
            day = dt.Substring(8, 2);
            DateTime dtd;
            //DateTime myDate = DateTime.Parse(date);
            return dtd = new DateTime(Convert.ToInt32(year), Convert.ToInt32(mounth), Convert.ToInt32(day), new System.Globalization.PersianCalendar());

        }

        public DateTime ConvertDatetoenglishforsearchaccounting(string dt)
        {
            string year = "";
            string mounth = "";
            string day = "";
            year = dt.Substring(0, 4);
            mounth = dt.Substring(5, 2);
            day = dt.Substring(8, 2);
            if (mounth[0] == '۰')
            {
                mounth = mounth[1] + "";
            }
            if (day[0] == '۰')
            {
                day = day[1] + "";
            }
            year = Changetoenglishchar(year);
            mounth = Changetoenglishchar(mounth);
            day = Changetoenglishchar(day);
            DateTime dtd;
            //DateTime myDate = DateTime.Parse(date);
            return dtd = new DateTime(Convert.ToInt32(year), Convert.ToInt32(mounth), Convert.ToInt32(day), new System.Globalization.PersianCalendar());

        }
    }
}