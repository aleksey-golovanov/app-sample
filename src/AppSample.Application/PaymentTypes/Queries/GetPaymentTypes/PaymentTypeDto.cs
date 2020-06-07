using AppSample.Application.Common.Mappings;
using AppSample.Core.Entities;
using AutoMapper;

namespace AppSample.Application.PaymentTypes.Queries.GetPaymentTypes
{
    public class PaymentTypeDto : IMapFrom<PaymentType>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<PaymentType, PaymentTypeDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.PaymentTypeId));
        }
    }
}
