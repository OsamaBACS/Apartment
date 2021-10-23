namespace BackEnd.Extensions
{
    public static class StringExtensions
    {
        public static bool isEmpty(this string s)
        {
            return string.IsNullOrEmpty(s.Trim());
        }
    }
}