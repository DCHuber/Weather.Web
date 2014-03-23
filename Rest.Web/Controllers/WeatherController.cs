using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using Weather.Web.Models;

namespace Weather.Web.Controllers
{
    public class WeatherController : ApiController
    {
        /// <summary>
        /// Pulls the weather information from Yahoo, and returns it as an HTTP response message
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Get()
        {
            // Get the weather information
            YahooWeather weather =  new YahooWeather();  
         
            // Create the response message from the weather object
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, weather);
            return response;
            
        }
        
    }

}
