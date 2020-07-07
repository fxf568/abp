namespace Skuo.Organization
{
    public class OrganizationPermissions
    {
        public const string GroupName = "Organization";

        public static class AbpOrganizations
        {
            public const string Default = GroupName + ".AbpOrganizations";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";

        }

     
        public static string[] GetAll()
        {
            return new[]
            {
                GroupName,
                AbpOrganizations.Default,
                AbpOrganizations.Delete,
                AbpOrganizations.Update,
                AbpOrganizations.Create
            };
        }
    }
}