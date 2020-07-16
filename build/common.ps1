# COMMON PATHS

$rootFolder = (Get-Item -Path "./" -Verbose).FullName

# List of solutions

$solutionPaths = (
    "../framework",
    "../modules/users",
    "../modules/permission-management",
    "../modules/setting-management",
    "../modules/feature-management",
    "../modules/identity",
    "../modules/identityserver",
    "../modules/tenant-management",
    "../modules/account",
    "../modules/docs",
    "../modules/blogging",
    "../modules/audit-logging",
    "../modules/background-jobs",
    "../modules/client-simulation",
    "../modules/virtual-file-explorer",
    "../templates/module/aspnet-core",
    "../templates/app/aspnet-core",
	
	"../Skuo.Modules/Skuo.Users",
	"../Skuo.Modules/Skuo.Account",
	"../Skuo.Modules/Skuo.Identity",
	"../Skuo.Modules/Skuo.IdentityServer",
	"../Skuo.Modules/Skuo.Snowflake",
	
    "../samples/MicroserviceDemo",
    "../abp_io/AbpIoLocalization"
)