using System.Web.Mvc;
using StackOverFlowApp.Web.Interface;

namespace StackOverFlowApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public ActionResult Index()
        {
            var questions = _unitOfWork.GetTopQuestions();
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
    }
}