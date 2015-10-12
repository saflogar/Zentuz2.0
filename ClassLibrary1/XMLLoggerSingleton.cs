using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Web.UI.DataVisualization.Charting;
using System.Diagnostics;


namespace GestureLog	
{
    public class XMLLoggerSingleton
    {
        private static readonly Lazy<XMLLoggerSingleton> _instance = new Lazy<XMLLoggerSingleton>(()=>new XMLLoggerSingleton(""));
        private readonly string _FILENAME = "GesturesLog.xml";
        private StringBuilder _sBuilder;
        private Stopwatch _StopWatch;
        
        public static XMLLoggerSingleton Instance 
        {
            get 
            {
                    return _instance.Value;
            }
        }


        private XMLLoggerSingleton(String filename)
        {
            
            _sBuilder = new StringBuilder();
            _StopWatch = new Stopwatch();

            using (StreamWriter stWriter = new StreamWriter(_FILENAME, true, Encoding.UTF8))
            {
                stWriter.WriteLine("by Sergio Flores; safgflores@hotmail.com");
            }
        }

        public void WriteLog(String element, String value) 
        {
            using(StringWriter sw = new StringWriter(_sBuilder))
            {
                using(XmlWriter xmlWritter = new XmlTextWriter(sw))
                {
                    xmlWritter.WriteStartElement(element);
                    xmlWritter.WriteEndElement();
                }
            }
        }


        public void WriteGestureLog(Dictionary<String,Point3D> gestureDict, string timeStamp) 
        {
        
                using (StringWriter sw = new StringWriter(_sBuilder))
                {
                    using (XmlWriter xmlWriter = new XmlTextWriter(sw))
                    {
                        //START MOVEMENT
                        xmlWriter.WriteStartElement("mov");
                        xmlWriter.WriteStartAttribute("time_stamp");
                        xmlWriter.WriteValue(timeStamp);
                        xmlWriter.WriteEndAttribute();
                        //PRINT ALL JOINTS
                        foreach (var point in gestureDict)
                        {
                            xmlWriter.WriteStartElement(point.Key);//START JOINT
                            xmlWriter.WriteStartElement("x");
                            xmlWriter.WriteValue(point.Value.X);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("Y");
                            xmlWriter.WriteValue(point.Value.Y);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("Z");
                            xmlWriter.WriteValue(point.Value.Z);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteEndElement();//END JOINT
                        }
                        xmlWriter.WriteEndElement();//END MOV
                }
                
            }
            WriteToXMLLogFile();
        }

        private void WriteToXMLLogFile() 
        {

            using (StreamWriter streamWriter = new StreamWriter(this._FILENAME,true,Encoding.UTF8))
            {
                streamWriter.Write(_sBuilder);
                _sBuilder.Clear();
            }
        
        }

   
    }
}
