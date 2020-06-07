using AppSample.Application.Common.Mappings;
using AppSample.Core.Entities;
using AutoMapper;

namespace AppSample.Application.Companies.Queries.GetCompanies
{
    public class CompanyDto : IMapFrom<Company>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Company, CompanyDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.CompanyId));
        }
    }
}
