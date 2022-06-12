namespace COMPANY.Common.Helpers
{
    using System;

    public static class IdentityDocument
    {
        public static string Generate(string prefix)
            => $"{prefix}::{GenerateId()}{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}";

        private static string GenerateId()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
                i *= ((int)b + 1);
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }
    }
}
