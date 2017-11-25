using System.Web.Mvc;
using StackOverFlowApp.Web.Interface;

namespace StackOverFlowApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public HomeController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        
        public ActionResult Index()
        {
            var questions = _serviceManager.GetTopQuestions();
            return View(questions);
        }

        public ActionResult Details(string questionid)
        {
            var questions = _serviceManager.GetQuestionById(questionid);
            return View(questions);
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "A little description about me.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "My contact.";

            return View();
        }

        [HttpGet]
        public JsonResult RefreshQuestions()
        {
            var questions = _serviceManager.GetTopQuestions();
            return  Json(questions, JsonRequestBehavior.AllowGet);
        }
    }
}