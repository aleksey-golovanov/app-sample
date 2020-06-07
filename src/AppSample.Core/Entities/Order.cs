using System;

namespace AppSample.Core.Entities
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string ClientAddress { get; set; }
        public int CompanyId { get; set; }
        public int PaymentTypeId { get; set; }
        public bool IsCompleted { get; set; }

        public virtual Company Company { get; set; }
        public virtual PaymentType PaymentType { get; set; }
    }
}
