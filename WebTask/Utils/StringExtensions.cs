using System.Runtime.CompilerServices;

namespace WebTask.Utils
{
    public static class StringExtensions
    {
        public static string BuilderURIService(this string str, string relativePath) {
            return string.Format("{0}/{1}", str.Trim('/'), relativePath.TrimStart('/'));
        }
    }
}
