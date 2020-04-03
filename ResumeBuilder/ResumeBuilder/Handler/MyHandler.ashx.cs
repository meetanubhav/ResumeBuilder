using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResumeBuilder.Handler
{
    /// <summary>
    /// Summary description for MyHandler
    /// </summary>
    public class MyHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("You Don't have permission to view this file.");
            context.Response.Redirect("~/Resume/AccessForbidden");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}