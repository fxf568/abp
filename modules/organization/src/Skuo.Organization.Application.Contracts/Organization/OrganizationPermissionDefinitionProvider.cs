using OrganizationService.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Skuo.Organization
{
    public class OrganizationPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var baseManagementGroup = context.AddGroup(OrganizationPermissions.GroupName, L("Permission:OrganizationService"));

            var baseTypes = baseManagementGroup.AddPermission(OrganizationPermissions.AbpOrganizations.Default, L("Permission:AbpOrganizations"));
            baseTypes.AddChild(OrganizationPermissions.AbpOrganizations.Update, L("Permission:AbpOrganizations:Edit"));
            baseTypes.AddChild(OrganizationPermissions.AbpOrganizations.Delete, L("Permission:AbpOrganizations:Delete"));
            baseTypes.AddChild(OrganizationPermissions.AbpOrganizations.Create, L("Permission:AbpOrganizations:Create"));
        }

        private static LocalizableString L(string name)
        {
             return LocalizableString.Create<OrganizationServiceResource>(name);
        }
    }
}