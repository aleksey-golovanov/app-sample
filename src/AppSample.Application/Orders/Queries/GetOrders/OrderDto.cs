using AppSample.Application.Common.Mappings;
using AppSample.Core.Entities;
using AutoMapper;
using System;

namespace AppSample.Application.Orders.Queries.GetOrders
{
    public class OrderDto : IMapFrom<Order>
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string ClientAddress { get; set; }
        public int CompanyId { get; set; }
        public string CompanyTitle { get; set; }
        public int PaymentTypeId { get; set; }
        public string PaymentTypeTitle { get; set; }
        public bool IsCompleted { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.OrderId))
                .ForMember(d => d.CompanyTitle, opt => opt.MapFrom(s => s.Company.Title))
                .ForMember(d => d.PaymentTypeTitle, opt => opt.MapFrom(s => s.PaymentType.Title));
        }
    }
}
