using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web.Mvc.Html
{
    /// <summary>
    /// Provides new collection of @Html helper extensions for File Uploading Drag N Drop...
    /// </summary>
    public static class InputExtensions
    {
        /// <summary>
        /// Writes an opening <form> tag to the response and sets the action tag to the specified
        /// controller, action, and route values. That will renders a form to be use for drag and 
        /// drop file transfer, by using the specified HTTP method and includes the HTML attributes.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="actionName">The name of the action method.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <returns>An opening <form> tag for drag and drop file upload specifics.</returns>
        public static MvcHtmlString FileUploadPanel(this HtmlHelper htmlHelper, string actionName, string controllerName)
        {
            string formTemplate = @"<form action='../{0}/{1}' method='post' enctype='multipart/form-data' id='dropzoneForm' class = 'dropzone'>                  
                                        < div class='fallback'>
                                            <input name='file' type='file' multiple />
                                            <input type='submit' value='Upload' />
                                        </div>
                                    </form>";
            return new MvcHtmlString(string.Format(formTemplate, actionName, controllerName));
        }

        /// <summary>
        /// Writes an opening <form> tag to the response and sets the action tag to the specified
        /// controller, action, and route values. That will renders a form to be use for drag and 
        /// drop file transfer, by using the specified HTTP method and includes the HTML attributes.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="actionName">The name of the action method.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An opening <form> tag for drag and drop file upload specifics.</returns>
        public static MvcHtmlString FileUploadPanel(this HtmlHelper htmlHelper, string actionName, string controllerName, object htmlAttributes)
        {
            string formTemplate = @"<form action='../{0}/{1}' method='post' enctype='multipart/form-data' id='dropzoneForm' {2}>                  
                                        <div class='fallback'>
                                            <input name='file' type='file' multiple />
                                            <input type='submit' value='Upload' />
                                        </div>
                                    </form>";
            return new MvcHtmlString(string.Format(formTemplate, actionName, controllerName, htmlAttributes.ToString().Replace(',', ' ')));
        }
    }
}