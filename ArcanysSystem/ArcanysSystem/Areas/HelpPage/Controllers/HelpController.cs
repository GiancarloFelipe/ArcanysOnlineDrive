using System;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using ArcanysSystem.Areas.HelpPage.ModelDescriptions;
using ArcanysSystem.Areas.HelpPage.Models;
using ArcanysSystem.EF.Processes;

namespace ArcanysSystem.Areas.HelpPage.Controllers
{
    /// <summary>
    /// The controller that will handle requests for the help page.
    /// </summary>
    public class HelpController : Controller
    {
        private const string ErrorViewName = "Error";

        public HelpController()
            : this(GlobalConfiguration.Configuration)
        {
        }

        public HelpController(HttpConfiguration config)
        {
            Configuration = config;
        }

        public HttpConfiguration Configuration { get; private set; }

        public ActionResult Index()
        {
            using (MenuProcess menuProcess = new MenuProcess())
            {
                ViewBag.NavigationLink = menuProcess.Get().Where(m => m.isEnabled == true);
            }

            ViewBag.DocumentationProvider = Configuration.Services.GetDocumentationProvider();
            return View(Configuration.Services.GetApiExplorer().ApiDescriptions);
        }

        public ActionResult Api(string apiId)
        {
            using (MenuProcess menuProcess = new MenuProcess())
            {
                ViewBag.NavigationLink = menuProcess.Get().Where(m => m.isEnabled == true);
            }

            if (!String.IsNullOrEmpty(apiId))
            {
                HelpPageApiModel apiModel = Configuration.GetHelpPageApiModel(apiId);
                if (apiModel != null)
                {
                    return View(apiModel);
                }
            }

            return View(ErrorViewName);
        }

        public ActionResult ResourceModel(string modelName)
        {
            using (MenuProcess menuProcess = new MenuProcess())
            {
                ViewBag.NavigationLink = menuProcess.Get().Where(m => m.isEnabled == true);
            }

            if (!String.IsNullOrEmpty(modelName))
            {
                ModelDescriptionGenerator modelDescriptionGenerator = Configuration.GetModelDescriptionGenerator();
                ModelDescription modelDescription;
                if (modelDescriptionGenerator.GeneratedModels.TryGetValue(modelName, out modelDescription))
                {
                    return View(modelDescription);
                }
            }

            return View(ErrorViewName);
        }
    }
}