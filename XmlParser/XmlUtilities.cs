using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.XPath;

namespace XmlParser
{
    public static class XmlUtilities
    {
        public static bool UpdateSingleXmLElement(this XElement xElement, string xPath, string newValue)
        {
            bool returnValue = false;
            try
            {
                XElement el = xElement.XPathSelectElement(xPath);
                if (el != null)
                {
                    el.SetValue(newValue);
                    returnValue = true;
                }
            }
            catch (Exception)
            {
                //TODO: Log This
                returnValue = false;
            }
            return returnValue;
        }

        public static void UpdateXmLElements(this XElement xElement, List<Tuple<string, string>> xPathsAndNewValues)
        {
            try
            {
                foreach (var xPathAndNewValue in xPathsAndNewValues)
                {
                    XElement el = xElement.XPathSelectElement(xPathAndNewValue.Item1);
                    if (el != null)
                    {
                        el.SetValue(xPathAndNewValue.Item2);
                    }
                }
            }
            catch (Exception)
            {
                //TODO: Log This?
            }
        }
   
    }
}