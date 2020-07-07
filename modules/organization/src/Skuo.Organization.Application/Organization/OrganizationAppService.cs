using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Skuo.Organization
{
    [Authorize(OrganizationPermissions.AbpOrganizations.Default)]
    public class OrganizationAppService : CrudAppService<OrganizationUnit, OrganizationDto, Guid, OrganizationPagedRequestDto,
        CreateUpdateAbpOrganizationDto, CreateUpdateAbpOrganizationDto>, IOrganizationAppService
    {
        private readonly IRepository<OrganizationUnit, Guid> _repository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly OrganizationManager _organizationManager;

        public OrganizationAppService(IRepository<OrganizationUnit, Guid> repository, OrganizationManager organizationManager, IOrganizationRepository organizationRepository)
            : base(repository)
        {
            _repository = repository;
            _organizationManager = organizationManager;
            _organizationRepository = organizationRepository;
            base.CreatePolicyName = OrganizationPermissions.AbpOrganizations.Create;
            base.UpdatePolicyName = OrganizationPermissions.AbpOrganizations.Update;
            base.DeletePolicyName = OrganizationPermissions.AbpOrganizations.Delete;
        }

        protected override IQueryable<OrganizationUnit> CreateFilteredQuery(OrganizationPagedRequestDto input)
        {
            return base.CreateFilteredQuery(input).Where(r => r.ParentId == input.ParentId);
        }


        public override async Task<PagedResultDto<OrganizationDto>> GetListAsync(OrganizationPagedRequestDto input)
        {
            PagedResultDto<OrganizationDto> baseResults = await base.GetListAsync(input);

            foreach (var baseResultsItem in baseResults.Items)
            {
                baseResultsItem.HasChildren = _repository.Any(r => r.ParentId == baseResultsItem.Id);
            }

            return baseResults;
        }


        public async Task<List<ViewTree>> GetViewTrees(Guid? guid)
        {
            List<ViewTree> viewTrees = (await _repository.GetListAsync()).Select(r => new ViewTree()
            {
                Guid = r.Id,
                Title = r.Name,
                //Selected = guid == r.ParentId ? true : false,
                ParentGuid = r.ParentId
            }).ToList();


            var viewTree = viewTrees.FirstOrDefault(r => r.Guid == guid);
            if (viewTree != null)
            {
                viewTrees.ForEach(r => { r.Selected = r.Guid == viewTree.ParentGuid ? true : false; });
            }

            return viewTrees.ComboboxTreeJson();
        }

        public async Task<List<ViewTree>> GetUserViewTrees(Guid? userId)
        {
            List<ViewTree> viewTrees = (await _repository.GetListAsync()).Select(r => new ViewTree()
            {
                Guid = r.Id,
                Title = r.Name,
                //Selected = guid == r.ParentId ? true : false,
                ParentGuid = r.ParentId
            }).ToList();

            if (userId != null)
            {
                List<OrganizationUnit> organizations = await _organizationRepository.GetOrganizationsAsync((Guid)userId);

                organizations.ForEach(u =>
                {
                    viewTrees.ForEach(r =>
                    {
                        if (r.Guid == u.Id)
                        {
                            r.Checked = true;
                        }
                    });
                });
            }

            return viewTrees.ComboboxTreeJson();
        }

        public async Task SetOrganizationsAsync(SetUserOrgaizationDto orgaizationDto)
        {
            await _organizationManager.SetOrganizationsAsync(orgaizationDto.UserId, orgaizationDto.OrganizationIds);
        }
    }
}