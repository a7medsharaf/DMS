using AutoMapper;
using DMS.DTModels.KnowledgePools;
using DMS.Models;

namespace DMS.Data
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<KnowledgePool, KPReturn>();
            CreateMap<KPReturn, KnowledgePool>();
        }
        }
}
