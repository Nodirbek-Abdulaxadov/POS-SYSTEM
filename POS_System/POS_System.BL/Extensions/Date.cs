namespace POS_System.BL.Extensions
{
    public class Date
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public Date(string date, char splitChar)
        {
            string[] vs = date.Split(splitChar);
            Day = int.Parse(vs[0]);
            Month = int.Parse(vs[1]);
            Year = int.Parse(vs[2]);
        }

        public Date(DateTime dateTime)
        {
            string[] vs1 = dateTime.ToString().Split(" ");
            string[] vs = vs1[0].Split('/');
            Day = int.Parse(vs[0]);
            Month = int.Parse(vs[1]);
            Year = int.Parse(vs[2]);
        }

        public string ToStringDate(Date date, char formatChar)
        {
            return $"{date.Day}{formatChar}{date.Month}{formatChar}{date.Year}";
        }
    }
}
