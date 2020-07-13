using Skuo.Users;

namespace Skuo.Identity
{
    public static class IdentityUserConsts
    {
        public static int MaxUserNameLength { get; set; } = SkuoUserConsts.MaxUserNameLength;

        public static int MaxNameLength { get; set; } = SkuoUserConsts.MaxNameLength;

        public static int MaxSurnameLength { get; set; } = SkuoUserConsts.MaxSurnameLength;

        public static int MaxNormalizedUserNameLength { get; set; } = MaxUserNameLength;

        public static int MaxEmailLength { get; set; } = SkuoUserConsts.MaxEmailLength;

        public static int MaxNormalizedEmailLength { get; set; } = MaxEmailLength;

        public static int MaxPhoneNumberLength { get; set; } = SkuoUserConsts.MaxPhoneNumberLength;

        public static int MaxPasswordLength { get; set; } = 128;

        public static int MaxPasswordHashLength { get; set; } = 256;

        public static int MaxSecurityStampLength { get; set; } = 256;

        public static int MaxConcurrencyStampLength { get; set; } = 256;
    }
}
