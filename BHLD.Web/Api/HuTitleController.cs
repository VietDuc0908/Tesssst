using BHLD.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BHLD.Web.Api
{
    [RoutePrefix("api/hutitle")]
    public class HuTitleController : APIControllerBase
    {
        Ihu_titleServices _ihutitleService;
        public HuTitleController(IErrorService errorService, Ihu_titleServices _ihutitleService):base(errorService)
        {
            this._ihutitleService = _ihutitleService;
        }


        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var listTitle = _ihutitleService.GetAll();

                    response = request.CreateResponse(HttpStatusCode.OK, listTitle);
                }
                return response;
            }
            );
        }

    }
}
