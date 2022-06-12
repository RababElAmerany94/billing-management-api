namespace COMPANY.Common.Helpers
{
    /// <summary>
    /// class describe strings helpers
    /// </summary>
    public static class StringHelper
    {
        public static bool IsValid(this string value)
            => !string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value);
    }
}
