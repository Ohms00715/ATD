using System;
using System.Globalization;

namespace ATD.Management
{
	public static class Helper
	{

		public static string GetValue(string messageText, int length)
		{
			string ret = "";
			if (messageText.Length >= length)
			{
				ret = messageText.Substring(0, length);
				messageText = messageText.Remove(0, length);
			}
			else
			{
				ret = messageText.Trim();
				messageText = "";
			}
			return ret;
		}

		public static int GetValue(string messageText, int length, int defaultValue)
		{
			int ret = defaultValue;

			string text = GetValue(messageText, length);
			if (text != "")
			{
				try
				{
					ret = Convert.ToInt32(text);
				}
				catch
				{
					ret = defaultValue;
				}
			}
			return ret;
		}

		public static decimal GetValue(string messageText, int length, decimal scale, decimal defaultValue)
		{
			decimal ret = defaultValue;

			string text = GetValue(messageText, length);
			if (text != "")
			{
				try
				{
					ret = Convert.ToDecimal(text) * scale;
				}
				catch
				{
					ret = defaultValue;
				}
			}
            else
            {
                ret = 0 ;
            }
			return ret;
		}

		public static DateTime GetValue(string messageText, bool includeTime, DateTime defaultValue)
		{
			DateTime ret = defaultValue;

			string text;
			if (includeTime == true)
			{
				text = GetValue(messageText, 14);
			}
			else
			{
				text = GetValue(messageText, 8) + "000000";
			}
			string s =
				string.Format(
					"{0}/{1}/{2} {3}:{4}:{5}",
					text.Substring(0, 4),
					text.Substring(4, 2),
					text.Substring(6, 2),
					text.Substring(8, 2),
					text.Substring(10, 2),
					text.Substring(12, 2));
			if (s.Length == 19)
			{
				CultureInfo culture = new CultureInfo("en-US");
				try
				{
					ret = Convert.ToDateTime(s, culture);
				}
				catch
				{
					ret = defaultValue;
				}
			}
			return ret;
		}

		public static string GetString(string value, int length)
		{
			string ret = value.Trim();
			if (ret.Length >= length)
			{
				ret = ret.Substring(0, length);
			}
			else
			{
				for (int i = ret.Length; i < length; i++)
				{
					ret += " ";
				}
			}
			return ret;
		}

		public static string GetString(int value, int length)
		{
			string ret = value.ToString();
			if (ret.Length < length)
			{
				for (int i = ret.Length; i < length; i++)
				{
					ret = "0" + ret;
				}
			}
			return ret;
		}

		public static string GetString(decimal value, decimal scale, int length)
		{
			string ret = (value * scale).ToString("N0").Replace(",", "").Replace(".", "");
			if (ret.Length < length)
			{
				for (int i = ret.Length; i < length; i++)
				{
					ret = "0" + ret;
				}
			}
			return ret;
		}

		public static string GetDateString(DateTime value)
		{
			string ret = value.ToString("yyyyMMdd");
			int year = Convert.ToInt32(ret.Substring(0, 4));
			if (year >= 2500)
			{
				year = year - 543;
			}
			return string.Format("{0}{1}", year.ToString(), ret.Substring(4, 4));
		}

		public static string GetTimeString(DateTime value)
		{
			return value.ToString("HHmmss");
		}

		public static string GetDateTimeString(DateTime value)
		{
			return string.Format("{0}{1}", GetDateString(value), GetTimeString(value));
		}

        public static decimal GetNominalLength(decimal orderThick, decimal orderWidth, decimal weightMT , string  unitCode)
        {
            decimal decReturn = (decimal)0.00;
            string decStr = "";
            try
            {
                

                if (orderThick.ToString().Length == 0) { orderThick = (decimal)0.00; }
                if (orderWidth.ToString().Length == 0) { orderWidth = (decimal)0.00; }
                if (weightMT.ToString().Length == 0) { weightMT = (decimal)0.00; }

                if (weightMT != 0)
                {
                    if (unitCode.ToUpper().Equals("KG"))
                    {
                        weightMT = (weightMT / 1000);
                    }
                }
                
                //return Convert.ToDecimal(((decimal)(weightMT / (thick * width * (decimal)0.00000785) / (decimal)1000)).ToString("N2"));
                if (weightMT == 0 || orderThick == 0 || orderWidth == 0 )
                {
                    //return (decimal)0.00;
                }
                else
                {
                    decReturn  =  (decimal)(weightMT / (orderThick * orderWidth * (decimal)0.00000785)); // KG
                    decStr = decReturn.ToString("#,#00.00");
                    decimal.TryParse(decStr, out decReturn);
                }

            }
            catch
            {
                //return (decimal)0.00; ;
            }

            return decReturn;
        }

        public static int GetOutsideDiameter(decimal width, decimal weight, decimal insideDiameter)
        {
            try
            {
                if (insideDiameter == null) { insideDiameter = 0; }
                if (width == null) { width = 0; }
                if (weight == null) { weight = 0; }

                return (int)(Math.Sqrt((double)((weight + (((decimal)22 / (decimal)7) * insideDiameter * insideDiameter / (decimal)4 * width * (decimal)0.00000785)) /
                    (((decimal)22 / (decimal)7) / (decimal)4 * width * (decimal)0.00000785))));
            }
            catch
            {
                return 0;
            }
        }

        public static DateTime getCurrentDateTime(string connStr)
        {
            DateTime dtDateTime;

            using (System.Data.SqlClient.SqlConnection connect = new System.Data.SqlClient.SqlConnection(connStr))
            {
                connect.Open();
                dtDateTime = DataHelper.ExecuteServerDateTime(connect);
            }

            return dtDateTime;
        }
	}
}

