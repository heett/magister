using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace magister
{
    public class log
    {
        //конструктор
      public log()
        {
        }
        public void write(string msg)
        {
            DateTime currtime = DateTime.Now;
            int day = currtime.Day;
            int mounth = currtime.Month;
            int year = currtime.Year;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(day+"-"+mounth + "-" + year+@".txt", true, Encoding.GetEncoding(1251)))
            {
                string tmptxt = String.Format("{0}\n{1}",currtime,msg);
                file.WriteLine(tmptxt);
                file.Close();
            }
        }
    }
}
