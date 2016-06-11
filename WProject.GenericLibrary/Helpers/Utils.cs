using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WProject.GenericLibrary.Helpers.Extensions;

namespace WProject.GenericLibrary.Helpers
{
    [Flags]
    public enum RandomStringRange
    {
        LowerCase = 1,
        UppperCase = 2,
        Numbers = 4,
        Hex = 8,
        Symbols = 16,
        LowerAlphanumeric = LowerCase | Numbers,
        UpperAlphanumeric = UppperCase | Numbers,
        Alpha = LowerCase | UppperCase,
        Alphanumeric = Alpha | Numbers,
        All = Alphanumeric | Symbols
    }

    public enum RandomDateRange
    {
        OnlyPositive,
        OnlyNegative,
        Both
    }

    public static class Utils
    {
        private static Random _randField;

        private static readonly string[] SizeSuffixes = { "b", "kb", "mb", "gb", "tb", "pb", "eb", "zb", "yb" };

        private const string LOWERCASE_CHARACTERS = "abcdefghijklmnopqrstuvwxyz";
        private const string UPPERCASE_CHARACTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string NUMBER_CHARACTERS = "0123456789";
        private const string HEX_CHARACTERS = NUMBER_CHARACTERS + "abcdef";
        private const string SYMBOL_CHARACTERS = ".,/'\";:[]{}\\|~`!@#$%^&*()-_+=";
        private const string ALPHA_CHARACTERS = LOWERCASE_CHARACTERS + UPPERCASE_CHARACTERS;
        private const string ALPHANUMERIC_CHARACTERS = ALPHA_CHARACTERS + NUMBER_CHARACTERS;
        private const string ALL_CHARACTERS = ALPHANUMERIC_CHARACTERS + SYMBOL_CHARACTERS;

        static Utils()
        {
            _randField = new Random();
        }

        public static bool EqualsToAny<T>(T m, params T[] members) where T : IEquatable<T>
        {
            return members.Any(t => t.Equals(m));
        }

        public static string MinutesToTime(int minutes)
        {
            var mtime = TimeSpan.FromMinutes(minutes);

            IList<string> mstime = new List<string>();

            if (mtime.Days > 0)
                mstime.Add(mtime.Days + "d");

            if (mtime.Hours > 0)
                mstime.Add(mtime.Hours + "h");

            if (mtime.Minutes > 0)
                mstime.Add(mtime.Minutes + "m");

            return string.Join(" ", mstime);
        }

        public static bool RandomBool()
        {
            return _randField.Next(0, 2) == 0;
        }

        public static int RandomInt(int min = 0, int max = int.MaxValue)
        {
            return _randField.Next(min, max);
        }

        public static string RandomString(RandomStringRange range = RandomStringRange.Alphanumeric)
        {
            return RandomString(RandomInt(0, 255), range);
        }

        public static string RandomString(string characters)
        {
            return RandomString(RandomInt(0, 255), characters);
        }

        public static string RandomString(int length, RandomStringRange range = RandomStringRange.Alphanumeric)
        {
            string mchars = string.Empty;

            if (range == RandomStringRange.All)
                return RandomString(length, ALL_CHARACTERS);

            if (range.HasFlag(RandomStringRange.LowerCase))
                mchars += LOWERCASE_CHARACTERS;

            if (range.HasFlag(RandomStringRange.UppperCase))
                mchars += UPPERCASE_CHARACTERS;

            if (range.HasFlag(RandomStringRange.Numbers))
                mchars += NUMBER_CHARACTERS;

            if (range.HasFlag(RandomStringRange.Hex))
                mchars += HEX_CHARACTERS;

            if (range.HasFlag(RandomStringRange.Symbols))
                mchars += SYMBOL_CHARACTERS;

            return RandomString(length, mchars);
        }

        public static string RandomString(int length, string characters)
        {
            return new string(characters.Select(c => characters[_randField.Next(characters.Length)]).Take(length).ToArray());
        }

        public static DateTime RandomDateTime(RandomDateRange range = RandomDateRange.Both, DateTime? min = null, DateTime? max = null)
        {
            DateTime start = min ?? new DateTime(1995, 1, 1);
            int mrange = (DateTime.Today - start).Days;
            return start.AddDays(_randField.Next(mrange));
        }

        public static string FormatToSize(long value, bool upperSufixes = false, string format = "N2", CultureInfo culture = null)
        {
            if (value < 0)
                return "-" + FormatToSize(value * -1, upperSufixes);

            if (value == 0)
                return "0.0 " + (upperSufixes ? SizeSuffixes[0].ToUpper() : SizeSuffixes[0]); 

            int mag = (int)Math.Log(value, 1024);
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            string ms = upperSufixes ? SizeSuffixes[mag].ToUpper() : SizeSuffixes[mag];

            return $"{adjustedSize.ToString(format, culture ?? CultureInfo.DefaultThreadCurrentCulture)} {ms}";
        }

        public static int TryIntParse(string text, int @default)
        {
            return TryIntParse(text, (int?) @default) ?? @default;
        }

        public static int? TryIntParse(string text, int? @default)
        {
            int mv;

            if (string.IsNullOrEmpty(text))
                return @default;

            if (int.TryParse(text, out mv))
                return mv;
            return @default;
        }
    }
}
