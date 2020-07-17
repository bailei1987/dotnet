namespace BL.Common
{
    public static class StringExtension
    {
        public static string ToCamel(this string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            return s[0].ToString().ToLower() + s.Substring(1);
        }
    }
}
