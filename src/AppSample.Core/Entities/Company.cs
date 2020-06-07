using System.Collections.Generic;

namespace AppSample.Core.Entities
{
    public partial class Company
    {
        public Company()
        {
            Order = new HashSet<Order>();
        }

        public int CompanyId { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
