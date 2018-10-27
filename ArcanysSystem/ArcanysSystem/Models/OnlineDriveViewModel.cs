using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArcanysSystem.Models
{
    /// <summary>
    /// Provides data model for OnlineDrive.
    /// </summary>
    public class OnlineDriveViewModel
    {
        /// <summary>
        /// Converts the ArcanysSystem.Models.OnlineDriveViewModel data to ArcanysSystem.EF.Models.OnlineDrive.
        /// </summary>
        /// <returns>Returns the converted value from ArcanysSystem.Models.OnlineDriveViewModel data to ArcanysSystem.EF.Models.OnlineDrive.</returns>
        public ArcanysSystem.EF.Models.OnlineDrive ToOnlineDrive()
        {
            ArcanysSystem.EF.Models.OnlineDrive onlineDrive = new ArcanysSystem.EF.Models.OnlineDrive();
            onlineDrive.Id = this.Id;
            onlineDrive.FileNameGUID = this.FileNameGUID;
            onlineDrive.FileName = this.FileName;
            onlineDrive.FilePath = this.FilePath;
            onlineDrive.UploadedOn = this.UploadedOn;
            onlineDrive.UploadedBy = this.UploadedBy;
            onlineDrive.LastUpdatedOn = this.LastUpdatedOn;
            onlineDrive.LastUpdatedBy = this.LastUpdatedBy;
            onlineDrive.DeletedOn = this.DeletedOn;
            onlineDrive.DeletedBy = this.DeletedBy;
            return onlineDrive;
        }
        /// <summary>
        /// Gets or Sets the row id of the uploaded file.
        /// </summary>
        [Display(Name = "Id")]
        public int RowID { get; set; }
        /// <summary>
        /// Gets or Sets the id for the uploaded file.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or Sets the guid for the uploaded file.
        /// </summary>
        [Display(Name = "GUID")]
        public string FileNameGUID { get; set; }
        /// <summary>
        /// Gets or Sets the file name of the uploaded file.
        /// </summary>
        [Display(Name = "File Name")]
        public string FileName { get; set; }
        /// <summary>
        /// Gets or Sets the file path of the uploaded file.
        /// </summary>
        [Display(Name = "File Path")]
        public string FilePath { get; set; }
        /// <summary>
        /// Gets or Sets the uploaded date of the uploaded file.
        /// </summary>
        [Display(Name = "Uploaded Date")]
        public System.DateTime UploadedOn { get; set; }
        /// <summary>
        /// Gets or Sets the identity of the uploader of the file.
        /// </summary>
        [Display(Name = "Uploaded By")]
        public int UploadedBy { get; set; }
        /// <summary>
        /// Gets or Sets the last updated date of the uploaded file.
        /// </summary>
        [Display(Name = "Last Updated Date")]
        public Nullable<System.DateTime> LastUpdatedOn { get; set; }
        /// <summary>
        /// Gets or Sets the identity of the last uploader of the file.
        /// </summary>
        [Display(Name = "Last Update By")]
        public Nullable<int> LastUpdatedBy { get; set; }
        /// <summary>
        /// Gets or Sets the deleted date of the uploaded file.
        /// </summary>
        [Display(Name = "Deleted Date")]
        public Nullable<System.DateTime> DeletedOn { get; set; }
        /// <summary>
        /// Gets or Sets the identity of the deleter of the uploaded file.
        /// </summary>
        [Display(Name = "Deleted By")]
        public Nullable<int> DeletedBy { get; set; }
        /// <summary>
        /// Gets or Sets the action name of the last executed button. 
        /// </summary>
        public string ButtonAction { get; set; }
    }
}