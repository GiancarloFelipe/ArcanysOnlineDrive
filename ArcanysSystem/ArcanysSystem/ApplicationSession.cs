using ArcanysSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArcanysSystem
{
    /// <summary>
    /// The application global session objets.
    /// </summary>
    public class ApplicationSession
    {
        /// <summary>
        /// Provides collection of global parameters for Online Drive Web Application.
        /// </summary>
        public static class GlobalParameters
        {
            private static int _ownerId;
            /// <summary>
            /// Gets or sets the unique id for the Owner.
            /// </summary>
            public static int OwnerId
            {
                get { return _ownerId = Convert.ToInt32(System.Web.HttpContext.Current.Session["OwnerId"]); }
                set { System.Web.HttpContext.Current.Session["OwnerId"] = _ownerId = value; }
            }

            private static string _uploadedFileNameGUID;
            /// <summary>
            /// Gets or sets the file name of the uploaded file.
            /// </summary>
            public static string UploadedFileNameGUID
            {
                get { return _uploadedFileNameGUID = System.Web.HttpContext.Current.Session["UploadedFileNameGUID"] == null ? string.Empty : System.Web.HttpContext.Current.Session["UploadedFileNameGUID"].ToString(); }
                set { System.Web.HttpContext.Current.Session["UploadedFileNameGUID"] = _uploadedFileNameGUID = value; }
            }

            private static string _uploadedFileName;
            /// <summary>
            /// Gets or sets the file name of the uploaded file.
            /// </summary>
            public static string UploadedFileName
            {
                get { return _uploadedFileName = System.Web.HttpContext.Current.Session["UploadedFileName"] == null ? string.Empty : System.Web.HttpContext.Current.Session["UploadedFileName"].ToString(); }
                set { System.Web.HttpContext.Current.Session["UploadedFileName"] = _uploadedFileName = value; }
            }

            private static string _uploadedFilePath;
            /// <summary>
            /// Gets or sets the file path of the uploaded file.
            /// </summary>
            public static string UploadedFilePath
            {
                get { return _uploadedFilePath = System.Web.HttpContext.Current.Session["UploadedFilePath"] == null ? string.Empty : System.Web.HttpContext.Current.Session["UploadedFilePath"].ToString(); }
                set { System.Web.HttpContext.Current.Session["UploadedFilePath"] = _uploadedFilePath = value; }
            }

            private static List<OnlineDriveViewModel> _uploadedFileList;
            /// <summary>
            /// Gets or sets the list of uploaded file.
            /// </summary>
            public static List<OnlineDriveViewModel> UploadedFileList
            {
                get { return _uploadedFileList = System.Web.HttpContext.Current.Session["UploadedFileList"] == null ? null : (List<OnlineDriveViewModel>)System.Web.HttpContext.Current.Session["UploadedFileList"]; }
                set { System.Web.HttpContext.Current.Session["UploadedFileList"] = _uploadedFileList = value; }
            }
        }
    }
}