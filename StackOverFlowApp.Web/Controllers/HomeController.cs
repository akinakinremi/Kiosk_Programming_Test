using System.Web.Mvc;
using StackOverFlowApp.Web.Interface;
using StackOverFlowApp.Web.DAL;

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
            //IUrlService urlService = new UrlService();
            _serviceManager.SetServiceUrl(new UrlService());
            var questions = _serviceManager.GetTopQuestions();
            return View(questions);
        }

        public ActionResult Details(string questionid)
        {
            //IUrlService urlService = new UrlService(questionid);
            _serviceManager.SetServiceUrl(new UrlService(questionid));
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