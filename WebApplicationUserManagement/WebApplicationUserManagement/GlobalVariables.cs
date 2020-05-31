using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace WebApplicationUserManagement
{
     /// <summary>
    /// This Class declares static member of WebApiClient for calling Rest Api from the Controller
    /// </summary>
    /// <author>Muhammad Asad Ashraf </author>
    /// <created>30-May-2020</created>
    /// <revisions>
    ///     <revision>
    ///         <author></author>
    ///         <date></date>
    ///         <remarks></remarks>
    ///     </revision>
    /// </revisions>
    public static class GlobalVariables
    {
        public static HttpClient WebApiClient = new HttpClient();

        static GlobalVariables()
        {
            WebApiClient.BaseAddress = new Uri("http://localhost:57071/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}