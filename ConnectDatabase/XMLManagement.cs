using System;
using System.Net;
using System.Xml;
using System.IO;
using System.ComponentModel;

namespace ConnectDatabase
{
    class XMLManagement
    {
        string xmlInputDir = "C:/Data Cuaca"; //Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\") + "/XML/");
        //string xmlParsedDir = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\") + "/ParsedXML/");

        public bool fileDownloaded = false;

        public void DownloadXML()
        {
            WebClient webClient = new WebClient();
            Uri url = new Uri(
                "https://data.bmkg.go.id/DataMKG/MEWS/DigitalForecast/DigitalForecast-JawaTimur.xml");

            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCallback2);
            webClient.DownloadFileAsync(url, xmlInputDir + "/DigitalForecast-JawaTimur.xml");
        }

        private void DownloadFileCallback2(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Console.WriteLine("File download cancelled.");
            }

            if (e.Error != null)
            {
                Console.WriteLine(e.Error.ToString());
            }

            if(e.Error == null)
            {
                Console.WriteLine("File Downloaded");
                fileDownloaded = true;
            }                       
        }

        public void MoveXML()
        {
            XmlDocument document = new XmlDocument();
            document.Load(xmlInputDir + 
                "/DigitalForecast-JawaTimur.xml");
            XmlNode timestamp = document.SelectSingleNode(
                "/data/forecast/issue/timestamp");

            File.Move(
                xmlInputDir + "/DigitalForecast-JawaTimur.xml", 
                xmlInputDir + "/DigitalForecast-JawaTimur-" + 
                timestamp.InnerText + ".xml");

            Console.WriteLine("\nFile Renamed");            
        }
    }
}
