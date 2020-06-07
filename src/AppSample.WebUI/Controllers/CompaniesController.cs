using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AppSample.Application.Companies.Queries.GetCompanies;
using AppSample.WebUI.Common;
using Microsoft.AspNetCore.Mvc;

namespace AppSample.WebUI.Controllers
{
    public class CompaniesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IList<CompanyDto>> Get(CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetCompaniesQuery(), cancellationToken);
        }
    }
}
