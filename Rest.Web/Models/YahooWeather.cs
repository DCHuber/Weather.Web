using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.XPath;
using System.Xml;
using System.Text;
using System.ServiceModel.Syndication;

namespace Weather.Web.Models
{
    public class YahooWeather
    {
        public string condition { get; set; }
        public string temperature { get; set; }
        public string date { get; set; }

        /// <summary>
        /// Simple RSS reader for Yahoo Weather - reads the current weather information for Woodland Park, CO
        /// </summary>
        public YahooWeather()
        {
            // Create a new XMLDocument
            XPathDocument doc = new XPathDocument("http://weather.yahooapis.com/forecastrss?w=2523310");

            // Create navigator
            XPathNavigator navigator = doc.CreateNavigator();

            // Set up namespace manager for XPath
            XmlNamespaceManager ns = new XmlNamespaceManager(navigator.NameTable);
            ns.AddNamespace("yweather", "http://xml.weather.yahoo.com/ns/rss/1.0");

            // Get condition with XPath
            XPathNodeIterator nodes = navigator.Select("/rss/channel/item/yweather:condition", ns);

            while(nodes.MoveNext())
            {
                XPathNavigator node = nodes.Current;

                condition = node.GetAttribute("text", ns.DefaultNamespace);
                temperature = node.GetAttribute("temp", ns.DefaultNamespace);
                date = node.GetAttribute("date", ns.DefaultNamespace);
            }

        }

    }
    
}