namespace POS_System.BL.Extensions
{
    public class DateOperations
    {
        private char formatChar = '/';
        
        public bool IsLater(string firstDate, string secondDate)
        {
            Date date1 = new Date(firstDate, formatChar);
            Date date2 = new Date(secondDate, formatChar);

            if (date1.Year > date2.Year)
            {
                return true;
            }
            else if (date1.Year == date2.Year)
            {
                if (date1.Month > date2.Month)
                {
                    return true;
                }
                else if (date1.Month == date2.Month)
                {
                    return date1.Day > date2.Day;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool IsLaterOrEqual(string firstDate, string secondDate)
        {
            Date date1 = new Date(firstDate, formatChar);
            Date date2 = new Date(secondDate, formatChar);

            if (date1.Year > date2.Year)
            {
                return true;
            }
            else if (date1.Year == date2.Year)
            {
                if (date1.Month > date2.Month)
                {
                    return true;
                }
                else if (date1.Month == date2.Month)
                {
                    return date1.Day >= date2.Day;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool IsEarlier(string firstDate, string secondDate)
        {
            Date date1 = new Date(firstDate, formatChar);
            Date date2 = new Date(secondDate, formatChar);

            if (date1.Year < date2.Year)
            {
                return true;
            }
            else if (date1.Year == date2.Year)
            {
                if (date1.Month < date2.Month)
                {
                    return true;
                }
                else if (date1.Month == date2.Month)
                {
                    return date1.Day < date2.Day;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool IsEarlierOrEqual(string firstDate, string secondDate)
        {
            Date date1 = new Date(firstDate, formatChar);
            Date date2 = new Date(secondDate, formatChar);

            if (date1.Year < date2.Year)
            {
                return true;
            }
            else if (date1.Year == date2.Year)
            {
                if (date1.Month < date2.Month)
                {
                    return true;
                }
                else if (date1.Month == date2.Month)
                {
                    return date1.Day <= date2.Day;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool Equals(string firstDate, string secondDate)
            => string.Equals(firstDate, secondDate);

        public string NDaysAgo(string date, int n)
        {
            Date data = new Date(date, formatChar);
            if (data.Day - n <= 0)
            {
                data.Day += GetMonthDays(--data.Month, data.Year);
                data.Day -= n;
            }
            else
            {
                data.Day -= n;
            }

            return data.ToStringDate(data, formatChar);
        }

        public string NMonthAgo(string date, int n)
        {
            Date data = new Date(date, formatChar);
            if (n >= data.Month)
            {
                data.Month += 12 - n;
                data.Year--;
                SetMonthDaysDifference(ref data);
                return data.ToStringDate(data, formatChar);
            }
            else
            {
                data.Month -= n;
                SetMonthDaysDifference(ref data);
                return data.ToStringDate(data, formatChar);
            }
        }
        public string NYearsAgo(string date, int n)
        {
            Date data = new Date(date, formatChar);
            data.Year -= n;
            SetMonthDaysDifference(ref data);
            return data.ToStringDate(data, formatChar);
        }

        private void SetMonthDaysDifference(ref Date date)
        {
            int monthDays = GetMonthDays(date.Month, date.Year);
            if (date.Day > monthDays)
            {
                date.Day = monthDays;
            }
        }

        private int GetMonthDays(int month, int year)
        {
            if (month % 12 == 0)
            {
                month = 12;
            }
            else if (month > 12 && month % 12 != 0)
            {
                month %= 12;
            }
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12: return 31;

                case 4:
                case 6:
                case 9:
                case 11: return 30;

                case 2:
                    {
                        if (IsLeapYear(year))
                        {
                            return 29;
                        }
                        else
                        {
                            return 28;
                        }
                    };
                default: return 0;
            }
        }

        private bool IsLeapYear(int year)
            => year % 4 == 0 && year % 100 != 0 || year % 400 == 0;

    }
}