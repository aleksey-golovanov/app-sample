using System.Collections.Generic;

namespace AppSample.Core.Entities
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            Order = new HashSet<Order>();
        }

        public int PaymentTypeId { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
