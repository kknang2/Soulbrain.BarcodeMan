using System;

namespace Soulbrain.BarcodeMan.Helpers
{
    public class DocCodeHelper
    {
        public static string GetNextDocCode(string prevCode = null)
        {
            var today = DateTime.Now;
            int suffix = 0;

            if (prevCode == null)
            {
                suffix = 1;
            }
            else
            {
                int year = Int32.Parse(prevCode.Substring(0, 2));
                int month = Int32.Parse(prevCode.Substring(2, 2));
                int day = Int32.Parse(prevCode.Substring(4, 2));
                int no = Int32.Parse(prevCode.Substring(6, 4));

                var prevDate = new DateTime(2000 + year, month, day);
                if (DateTime.Compare(today.Date, prevDate.Date) == 0)
                {
                    suffix = no + 1;
                }
                else
                {
                    suffix = 1;
                }
            }

            return string.Format("{0}{1}", today.ToString("yyMMdd"), suffix.ToString().PadLeft(4, '0'));
        }
    }
}
