using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace MVC
{
    public static class Bientoancuc
    {
        public static HttpClient WebApiClient = new HttpClient();

        static Bientoancuc()
        {
            WebApiClient.BaseAddress = new Uri("http://localhost:49998/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }
    }
}