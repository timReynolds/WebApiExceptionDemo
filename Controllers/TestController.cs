using System.Threading.Tasks;
using System.Web.Http;

namespace ExceptionDemo.Controllers
{
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        [Route("")]
        public IHttpActionResult Get()
        {
            throw new TaskCanceledException();
        }

        [Route("")]
        public IHttpActionResult Post()
        {
            throw new TaskCanceledException();
        }
    }
}