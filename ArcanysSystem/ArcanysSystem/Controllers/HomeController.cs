using ArcanysSystem.EF.Models;
using ArcanysSystem.EF.Processes;
using ArcanysSystem.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ArcanysSystem.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Private list for OnlineDrive model.
        /// </summary>
        private List<OnlineDriveViewModel> OnlineDriveList = new List<OnlineDriveViewModel>();

        // GET: Dashboard
        /// <summary>
        /// Provides action method for /Home/Index request.
        /// </summary>
        /// <returns>Return action result for /Home/Index request.</returns>
        public ActionResult Index()
        {
            // Set the view captions for this action method...
            ViewBag.Title = "Home Page";
            ViewBag.PageTitle = string.Empty;
            ViewBag.PageSubTitle = string.Empty;

            // Set the menus for the navigation side panel...
            using (MenuProcess menuProcess = new MenuProcess())
            {
                ViewBag.NavigationLink = menuProcess.Get().Where(m => m.isEnabled == true);
            }

            // Render the view as response to the request...
            return View();
        }

        // GET: OnlineDriveUpload
        /// <summary>
        /// Provides action method for /Home/OnlineDriveUpload request.
        /// </summary>
        /// <returns>Return action result for /Home/OnlineDriveUpload request.</returns>
        public ActionResult OnlineDriveUpload(int? page)
        {
            // Set the view captions for this action method...
            ViewBag.Title = "Online Drive File Uploading Page";
            ViewBag.PageTitle = "Upload Your Files Here...";
            ViewBag.PageSubTitle = "Simply drag en drop any files that you'd like to upload.";
            ViewBag.TableTitle = "Uploaded File List";

            // Reset all the uploaded file list first...
            ApplicationSession.GlobalParameters.UploadedFileList = new List<OnlineDriveViewModel>();
            ApplicationSession.GlobalParameters.UploadedFileList.Clear();
            this.OnlineDriveList = new List<OnlineDriveViewModel>();
            this.OnlineDriveList.Clear();

            // Set action button to default value is action is null...
            if (string.IsNullOrEmpty(ViewBag.ButtonAction))
                ViewBag.ButtonAction = String.Empty;

            // Set the menus for the navigation side panel...
            using (MenuProcess menuProcess = new MenuProcess())
            {
                ViewBag.NavigationLink = menuProcess.Get().Where(m => m.isEnabled == true);
            }

            // Populate the list of uploaded files...
            if (this.ModelState.IsValid)
            {
                try
                {
                    return this.View(this.GetOnlineDrive().ToList().ToPagedList(page ?? 1, 10));
                }
                catch (Exception ex) { throw ex; }
            }

            // Render the view as response to the request...
            return View();
        }

        /// <summary>
        /// Calls the web api procedure for OnlineDrive HTTP GET Method.
        /// </summary>
        /// <returns>Returns the ienumerable result of the http request.</returns>
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

        /// <summary>
        /// Calls the web api procedure for OnlineDrive HTTP POST Method.
        /// </summary>
        /// <param name="model">The ArcanysSystem.Models.OnlineDriveViewModel model.</param>
        /// <returns>Returns the ienumerable result of the http request.</returns>
        public IEnumerable<OnlineDriveViewModel> PostOnlineDrive(OnlineDriveViewModel model)
        {
            // Complete the model's value before sending the request...
            model.UploadedOn = DateTime.Now;
            model.UploadedBy = 1;
            model.LastUpdatedOn = null;
            model.LastUpdatedBy = null;

            IEnumerable<OnlineDriveViewModel> resultModel = null;
            // Start the http client request to call the web api...
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:3207/api/");
                // Send a post request for HTTP POST "api/OnlineDrive"...              
                using (Task<HttpResponseMessage> requestTask = client.PostAsJsonAsync<OnlineDriveViewModel>("OnlineDrive", model))
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

        /// <summary>
        /// Calls the web api procedure for OnlineDrive HTTP PUT Method.
        /// </summary>
        /// <param name="model">The ArcanysSystem.Models.OnlineDriveViewModel model.</param>
        /// <returns>Returns the ienumerable result of the http request.</returns>
        public IEnumerable<OnlineDriveViewModel> PutOnlineDrive(OnlineDriveViewModel model)
        {
            // Complete the model's value before sending the request...
            model.UploadedOn = DateTime.Now;
            model.UploadedBy = 1;
            model.LastUpdatedOn = null;
            model.LastUpdatedBy = null;

            IEnumerable<OnlineDriveViewModel> resultModel = null;
            // Start the http client request to call the web api...
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:3207/api/");
                // Send a get request for HTTP PUT "api/OnlineDrive"...            
                using (Task<HttpResponseMessage> requestTask = client.PutAsJsonAsync<OnlineDriveViewModel>("OnlineDrive", model))
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

        /// <summary>
        /// Calls the web api procedure for OnlineDrive HTTP DELETE Method.
        /// </summary>
        /// <param name="model">The ArcanysSystem.Models.OnlineDriveViewModel model.</param>
        /// <returns>Returns the ienumerable result of the http request.</returns>
        public IEnumerable<OnlineDriveViewModel> DeleteOnlineDrive(OnlineDriveViewModel model)
        {
            IEnumerable<OnlineDriveViewModel> resultModel = null;
            // Start the http client request to call the web api...
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:3207/api/");
                // Send a get request for HTTP DELETE "api/OnlineDrive"...            
                using (Task<HttpResponseMessage> requestTask = client.DeleteAsync(String.Format("OnlineDrive/{0}", model.Id)))
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

        // POST: /Home/UploadedFile
        /// <summary>
        /// The action method that provides result for /Home/UploadedFile request.
        /// </summary>
        /// <returns>Return Json Result for /Home/SaveForLater request.</returns>
        [HttpPost]
        public JsonResult UploadedFile(OnlineDriveViewModel model)
        {
            // Set the methods local variables...
            bool isFileUploadedSuccessfully = true;
            string uploadedFileNameGUID = string.Empty;

            // UPLOADING ALL THE INVOICE FILE(S)...
            try
            {
                // Checks each file request...
                foreach (string fileName in Request.Files)
                {
                    // Gets the uploaded file(s)...
                    HttpPostedFileBase requestFiles = Request.Files[fileName];
                    uploadedFileNameGUID = Guid.NewGuid().ToString();
                    if (requestFiles != null && requestFiles.ContentLength > 0)
                    {

                        // Gets the base directory information using the Server.MapPath...
                        var baseDirectoryInfo = new System.IO.DirectoryInfo(string.Format("{0}Images\\uploaded", Server.MapPath(@"\")));
                        string pathString = System.IO.Path.Combine(baseDirectoryInfo.ToString(), "imagepath", ApplicationSession.GlobalParameters.OwnerId.ToString().PadLeft(10, '0'));
                        var uploadedFileName = System.IO.Path.GetFileName(requestFiles.FileName);

                        // Checks if the directory path already exists, else create the directory...
                        bool isExists = System.IO.Directory.Exists(pathString);
                        if (!isExists)
                            System.IO.Directory.CreateDirectory(pathString);

                        // Save the uploaded file to the location path of the selected file...
                        var uplodedDocumentLocationPathToSave = string.Format("{0}\\{1}", pathString, uploadedFileNameGUID);
                        requestFiles.SaveAs(uplodedDocumentLocationPathToSave);

                        // Checks if the list of ApplicationSession.GlobalParameters.UploadedFileList has value...
                        if (ApplicationSession.GlobalParameters.UploadedFileList != null)
                        {
                            // Gets the existing list on the ApplicationSession.GlobalParameters.UploadedFileList and save it into the temporary OnlineDriveList...
                            this.OnlineDriveList = ApplicationSession.GlobalParameters.UploadedFileList;
                        }

                        // Add new list on the temporary OnlineDriveList...
                        OnlineDriveList.Add(new OnlineDriveViewModel
                        {
                            FileNameGUID = ApplicationSession.GlobalParameters.UploadedFileNameGUID = uploadedFileNameGUID,
                            FileName = ApplicationSession.GlobalParameters.UploadedFileName = uploadedFileName,
                            FilePath = ApplicationSession.GlobalParameters.UploadedFilePath = uplodedDocumentLocationPathToSave,
                        });

                        // Now save and set the new list of ApplicationSession.GlobalParameters.UploadedFileList...
                        ApplicationSession.GlobalParameters.UploadedFileList = this.OnlineDriveList;
                    }
                }
            }
            catch (Exception)
            {
                // Set the flag value to false if any unhandled exception occourred...
                isFileUploadedSuccessfully = false;
            }
            // Return the file uploading message result...
            if (isFileUploadedSuccessfully)
                return Json(new { Message = uploadedFileNameGUID });
            else
                return Json(new { Message = "Error in uploading the file." });
        }

        // GET: OnlineDriveUploadedDocumentSave
        /// <summary>
        /// Provides action method for /Home/OnlineDriveUploadedDocumentSave request.
        /// </summary>
        /// <param name="model">The ArcanysSystem.Models.OnlineDriveViewModel model</param>
        /// <param name="page">The index page to display with.</param>
        /// <returns>Return action result for /Home/OnlineDriveUploadedDocumentSave request.</returns>
        public ActionResult OnlineDriveUploadedDocumentSave(OnlineDriveViewModel model, int? page)
        {
            // Set the view captions for this action method...
            ViewBag.Title = "Online Drive Upload Page";
            ViewBag.PageTitle = "Upload Your Files Here...";
            ViewBag.PageSubTitle = "Simply drag en drop the file you'd like to upload on the drop box below.";
            ViewBag.TableTitle = "Uploaded File List";
            ViewBag.ButtonAction = model.ButtonAction;

            // Set the menus for the navigation side panel...
            using (MenuProcess menuProcess = new MenuProcess())
            {
                ViewBag.NavigationLink = menuProcess.Get().Where(m => m.isEnabled == true);
            }

            // Gets the uploaded filename...
            this.OnlineDriveList = ApplicationSession.GlobalParameters.UploadedFileList;

            // Validate id there was a file uploaded...
            if (this.OnlineDriveList == null)
                return RedirectToAction("OnlineDriveUpload");
            if (this.OnlineDriveList.Count() > 0)
            {
                try
                {
                    // Save all the uploaded files...
                    if (model.ButtonAction == "Upload")
                    {
                        foreach (var item in this.OnlineDriveList)
                        {
                            model.Id = item.Id;
                            model.FileNameGUID = item.FileNameGUID;
                            model.FileName = item.FileName;
                            model.FilePath = item.FilePath;
                            model.UploadedOn = DateTime.Now;
                            model.UploadedBy = 1;
                            model.LastUpdatedOn = DateTime.Now;
                            model.LastUpdatedBy = 1;
                            model.DeletedOn = DateTime.Now;
                            model.DeletedBy = 1;

                            if (this.ModelState.IsValid)
                            {
                                this.PostOnlineDrive(model);
                            }
                        }
                    }
                    ApplicationSession.GlobalParameters.UploadedFileList = null;
                    this.OnlineDriveList.Clear();
                }
                catch (Exception) { }
            }

            // Redirect action to OnlineDriveUpload...
            return RedirectToAction("OnlineDriveUpload");
        }

        // GET: OnlineDriveUploadedDocumentDelete
        /// <summary>
        /// Provides action method for /Home/OnlineDriveUploadedDocumentDelete request.
        /// </summary>
        /// <param name="model">The ArcanysSystem.Models.OnlineDriveViewModel model.</param>
        /// <returns>Return action result for /Home/OnlineDriveUploadedDocumentDelete request.</returns>
        public ActionResult OnlineDriveUploadedDocumentDelete(OnlineDriveViewModel model)
        {
            // Set the view captions for this action method...
            ViewBag.Title = "Online Drive Upload Page";

            // Delete the selected file...
            this.DeleteOnlineDrive(model);

            // Redirect action to OnlineDriveUpload...
            return RedirectToAction("OnlineDriveUpload");
        }

    }
}
