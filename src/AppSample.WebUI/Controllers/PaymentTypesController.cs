using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AppSample.Application.PaymentTypes.Queries.GetPaymentTypes;
using AppSample.WebUI.Common;
using Microsoft.AspNetCore.Mvc;

namespace AppSample.WebUI.Controllers
{
    public class PaymentTypesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IList<PaymentTypeDto>> Get(CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetPaymentTypesQuery(), cancellationToken);
        }
    }
}
