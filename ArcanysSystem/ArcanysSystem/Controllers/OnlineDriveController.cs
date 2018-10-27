using ArcanysSystem.EF.Processes;
using ArcanysSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ArcanysSystem.Controllers
{
    public class OnlineDriveController : ApiController
    {
        public List<OnlineDriveViewModel> ListOnlineDriveViewModel { get; set; }

        // GET api/OnlineDrive
        /// <summary>
        /// Provides a list of uploaded files for OnlineDrive Web Application System.
        /// </summary>
        /// <returns>Returns list of uploaded files.</returns>
        public IEnumerable<OnlineDriveViewModel> Get()
        {
            this.ListOnlineDriveViewModel = new List<OnlineDriveViewModel>();
            this.ListOnlineDriveViewModel.Clear();
            using (OnlineDriveProcess process = new OnlineDriveProcess())
            {
                int _rowid = 0;
                foreach (var item in process.Get())
                {
                    _rowid++;
                    this.ListOnlineDriveViewModel.Add(new OnlineDriveViewModel
                    {
                        RowID = _rowid,
                        Id = item.Id,
                        FileNameGUID = item.FileNameGUID,
                        FileName = item.FileName,
                        FilePath = item.FilePath,
                        UploadedOn = item.UploadedOn,
                        UploadedBy = item.UploadedBy,
                        LastUpdatedOn = item.LastUpdatedOn,
                        LastUpdatedBy = item.LastUpdatedBy,
                        DeletedOn = item.DeletedOn,
                        DeletedBy = item.DeletedBy
                    });
                }
            }
            return this.ListOnlineDriveViewModel;
        }

        // GET api/OnlineDrive/5
        /// <summary>
        /// Gets a list of uploaded files for OnlineDrive Web Application System.
        /// </summary>
        /// <param name="id">The id number of the uploaded file to get.</param>
        /// <returns>Returns list of uploaded files.</returns>
        public IEnumerable<OnlineDriveViewModel> Get(int id)
        {
            this.ListOnlineDriveViewModel = new List<OnlineDriveViewModel>();
            this.ListOnlineDriveViewModel.Clear();
            using (OnlineDriveProcess process = new OnlineDriveProcess())
            {
                int _rowid = 0;
                foreach (var item in process.Get(id))
                {
                    _rowid++;
                    this.ListOnlineDriveViewModel.Add(new OnlineDriveViewModel
                    {
                        RowID = _rowid,
                        Id = item.Id,
                        FileNameGUID = item.FileNameGUID,
                        FileName = item.FileName,
                        FilePath = item.FilePath,
                        UploadedOn = item.UploadedOn,
                        UploadedBy = item.UploadedBy,
                        LastUpdatedOn = item.LastUpdatedOn,
                        LastUpdatedBy = item.LastUpdatedBy,
                        DeletedOn = item.DeletedOn,
                        DeletedBy = item.DeletedBy
                    });
                }
            }
            return this.ListOnlineDriveViewModel;
        }

        // POST api/OnlineDrive
        /// <summary>
        /// Post a list of uploaded files for OnlineDrive Web Application System.
        /// </summary>
        /// <param name="model">The ArcanysSystem.Models.OnlineDriveViewModel model</param>
        public void Post(OnlineDriveViewModel model)
        {
            int affectedRows = 0;
            using (OnlineDriveProcess process = new OnlineDriveProcess())
            {
                affectedRows = process.Post(model.ToOnlineDrive());
            }
        }

        // PUT api/OnlineDrive/5
        /// <summary>
        /// Put a list of uploaded files for OnlineDrive Web Application System.
        /// </summary>
        /// <param name="model">The ArcanysSystem.Models.OnlineDriveViewModel model</param>
        public void Put(OnlineDriveViewModel model)
        {
            int affectedRows = 0;
            using (OnlineDriveProcess process = new OnlineDriveProcess())
            {
                affectedRows = process.Put(model.ToOnlineDrive());
            }
        }

        // DELETE api/OnlineDrive/5
        /// <summary>
        /// Delete a list of uploaded files for OnlineDrive Web Application System.
        /// </summary>
        /// <param name="id">The id number of the uploaded file to get.</param>
        public void Delete(int id)
        {
            int affectedRows = 0;
            using (OnlineDriveProcess process = new OnlineDriveProcess())
            {
                affectedRows = process.Delete(id);
            }
        }
    }
}
