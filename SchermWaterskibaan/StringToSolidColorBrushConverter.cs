/*
* Waterskibaan Project
* Door: Maaike van der Jagt
* ICTSE1a
* 2019
* Inspiration: https://stackoverflow.com/questions/6808739/how-to-convert-color-code-into-media-brush
*/

using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace SchermWaterskibaan
{
    public class StringToSolidColorBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            var hexString = (value.ToString() as string).Replace("#", "");

            if (string.IsNullOrWhiteSpace(hexString)) throw new FormatException();
            if (hexString.Length != 6 && hexString.Length != 8) throw new FormatException();

            try
            {
                var a = hexString.Length == 8 ? hexString.Substring(0, 2) : "255";
                var r = hexString.Length == 8 ? hexString.Substring(2, 2) : hexString.Substring(0, 2);
                var g = hexString.Length == 8 ? hexString.Substring(4, 2) : hexString.Substring(2, 2);
                var b = hexString.Length == 8 ? hexString.Substring(6, 2) : hexString.Substring(4, 2);

                return new SolidColorBrush(Color.FromArgb(
                    byte.Parse(a, NumberStyles.HexNumber),
                    byte.Parse(r, NumberStyles.HexNumber),
                    byte.Parse(g, NumberStyles.HexNumber),
                    byte.Parse(b, NumberStyles.HexNumber)));
            }
            catch
            {
                throw new FormatException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
        {
            throw new NotImplementedException();
        }
    }
}
