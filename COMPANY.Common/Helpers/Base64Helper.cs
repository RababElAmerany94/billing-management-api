namespace COMPANY.Common.Helpers
{
    using System.Linq;

    public static class Base64Helper
    {
        public static string FixBase64(this string base64)
           => base64.Split(',').Last();
    }
}
