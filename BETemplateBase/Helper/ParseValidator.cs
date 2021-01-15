using System;
using System.Globalization;

namespace Helper
{
    public static class ParseValidator
    {
        public static DateTime? ToDate(this string input)
        {
            return DateTime.TryParseExact(
                input,
                DateHelper.OnlyDatePattern,
                CultureInfo.InvariantCulture,
                DateTimeStyles.AdjustToUniversal,
                out DateTime convertedInput) ? convertedInput : (DateTime?)null;
        }

        public static long? ToLong(this string input)
        {
            if (long.TryParse(input, out long convertedInput)) { return convertedInput; }
            return null;
        }

        public static int? ToInt(this string input)
        {
            if (int.TryParse(input, out int convertedInput)) { return convertedInput; }
            return null;
        }

        public static decimal? ToDecimal(this string input)
        {
            if (decimal.TryParse(input, NumberStyles.Currency, CultureInfo.InvariantCulture, out decimal exchangerate)) { return exchangerate; }
            return null;
        }

        public static bool? ToBool(this string input)
        {
            if (bool.TryParse(input, out bool convertedInput)) { return convertedInput; }
            return null;
        }

        public static byte? ToByte(this string input)
        {
            if (byte.TryParse(input, out byte convertedInput)) { return convertedInput; }
            return null;
        }

        public static Guid? ToGuidNulleable(this string input)
        {
            if (Guid.TryParse(input, out Guid convertedInput)) { return convertedInput; }
            return null;
        }

        public static Guid ToGuid(this string input)
        {
            var result = input.ToGuidNulleable();
            return result ?? default;
        }

        public static string ConvertFromCommaToPoint(decimal value)
        {
            return value.ToString("0.00", CultureInfo.InvariantCulture);
        }

        public static string ToStringNullSafe(this object value)
        {
            return (value ?? string.Empty).ToString();
        }
    }
}
