using System.Xml.Linq;
using UmbrellaCore.Interfaces;

namespace XmlFormatterPlugin
{
    public class XmlFormatter : IDataTransformer
    {
        public string Name => "XML Formatter";

        public string TransformBeforeSave(string data)
        {
            XDocument doc = XDocument.Parse(data);

            return doc.ToString();
        }

        public string TransformAfterLoad(string data)
        {
            return data;
        }
    }
}