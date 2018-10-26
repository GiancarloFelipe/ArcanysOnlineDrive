using ArcanysSystem.EF.Processes;
using ArcanysSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ArcanysSystem.Controllers
{
    public class ApplicationController : Controller
    {
        // GET: Dashboard
        /// <summary>
        /// Provides action method for /Application/Dashboard request.
        /// </summary>
        /// <returns>Return action result for /Application/Dashboard request.</returns>
        public ActionResult Dashboard()
        {
            // Set the view captions for this action method...
            ViewBag.Title = "Dashboard Page";
            ViewBag.PageTitle = "Dashboard";
            ViewBag.PageSubTitle = "Provide at-a-glance views of KPIs (key performance indicators) relevant to online drive system of arcanys.";

            // Set the menus for the navigation side panel...
            using (MenuProcess menuProcess = new MenuProcess())
            {
                ViewBag.NavigationLink = menuProcess.Get().Where(m => m.isEnabled == true);
            }

            // Set the total of files stored on the online drive...
            int totalFiles = GetOnlineDrive().Count();
            if (totalFiles <= 1)   
                ViewBag.TotalUploadedFile = String.Format("{0} {1}", totalFiles, "Total File on the Drive!");     
            else        
                ViewBag.TotalUploadedFile = String.Format("{0} {1}", totalFiles, "Total Files on the Drive!");          

            // Render the view as response to the request...
            return View();
        }

        /// <summary>
        /// Calls the web api procedure for OnlineDrive HTTP GET Method.
        /// </summary>
        /// <returns>Returns the list of uploaded files on Online Drive.</returns>
        public IEnumerable<OnlineDriveViewModel> GetOnlineDrive()
        {
            IEnumerable<OnlineDriveViewModel> resultModel = null;
            // Start the http client request to call the web api...
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:3207/api/");
                // Send a get request for HTTP GET "api/OnlineDrive"...             
                using (Task<HttpResponseMessage> requestTask = client.GetAsync("OnlineDrive"))
                {
                    requestTask.Wait();
                    HttpResponseMessage resultTask = requestTask.Result;
                    if (resultTask.IsSuccessStatusCode)
                    {
                        Task<IList<OnlineDriveViewModel>> readTask = resultTask.Content.ReadAsAsync<IList<OnlineDriveViewModel>>();
                        readTask.Wait();
                        resultModel = readTask.Result;
                    }
                    else
                    {
                        resultModel = Enumerable.Empty<OnlineDriveViewModel>();
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
            }
            return resultModel;
        }
    }
}