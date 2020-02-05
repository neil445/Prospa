namespace Prospa.BusinessMatcher.Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Prospa.BusinessMatcher.Api.Extensions;
    using Prospa.BusinessMatcher.Api.Models;
    using Prospa.BusinessMatcher.Service;

    public class BusinessRecordsController : ApiController
    {
        private readonly IBusinessRecordsService businessRecordsService;

        public BusinessRecordsController(IBusinessRecordsService businessRecordsService)
        {
            this.businessRecordsService = businessRecordsService;
        }

        /// <summary>
        /// Submit business information.
        /// </summary>
        /// <param name="payload">business information to submit</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid request</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        public async Task<IHttpActionResult> Post(BusinessWebModel payload) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await this.businessRecordsService.CreateOrUpdateBusinessRecordAsync(payload.ToServiceModel());

                    return this.Ok(result.ToViewModel());
                }

                return this.BadRequest();
            }
            catch (Exception)
            {
                // log exception here
                return this.InternalServerError();
            }
        }
    }
}