using System.Collections.Generic;
using System.Web.Http;

namespace StackOverFlowApp.Web.Controllers
{
    public class QuestionController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

    }
}