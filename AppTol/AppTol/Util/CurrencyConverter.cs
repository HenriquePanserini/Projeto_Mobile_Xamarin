using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace AppTol.Util
{
    internal class CurrencyConverter:IValueConverter
    {

        public object Convert(object value, Type targetType, object parameters, CultureInfo culture)
        {
            NumberFormatInfo nfi = new CultureInfo("pt-BR").NumberFormat;
            return Decimal.Parse(value.ToString()).ToString("C",nfi);
        }

        public object ConvertBack(object value, Type targetType, object parameters, CultureInfo culture)
        {

            string valueFromString = Regex.Replace(value.ToString(), @"\D", "");

            if (valueFromString.Length <= 0)
                return 0m;

            long valueLong;
            if (!long.TryParse(valueFromString, out valueLong))
                return 0m;

            if (valueLong <= 0)
                return 0m;

            return valueLong / 100m;
        }

    }
}
