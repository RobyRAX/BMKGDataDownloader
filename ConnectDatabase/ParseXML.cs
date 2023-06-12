using System;
using System.Xml;

namespace ConnectDatabase
{
    public class ParseXML
    {
        string xmlInputDir = "C:/Data Cuaca";

        public static int arrayCount = 0;

        Connect connect = new Connect();

        public void Parse()
        {
            Console.WriteLine("Entry Started");

            string[] tableArr = new string[31];

            XmlDocument document = new XmlDocument();
            document.Load(xmlInputDir + "/DigitalForecast-JawaTimur.xml");

            XmlNode data = document.SelectSingleNode("/data");
            XmlNode forecast = document.SelectSingleNode("/data/forecast");
            XmlNode issue = document.SelectSingleNode("/data/forecast/issue");
            XmlNodeList area = document.GetElementsByTagName("area");

            ///////////////////////////////////////////////////////////////////////

            foreach (XmlNode node in area)
            {
                foreach (XmlNode childNode in node.ChildNodes) //Child node "area" == name && parameter
                {
                    if (childNode.Name == "name")
                    {
                        tableArr[0] = data.Attributes["source"].Value;
                        tableArr[1] = data.Attributes["productioncenter"].Value;
                        tableArr[2] = forecast.Attributes["domain"].Value;
                        tableArr[3] = issue.ChildNodes[0].InnerText;
                        tableArr[4] = issue.ChildNodes[1].InnerText;
                        tableArr[5] = issue.ChildNodes[2].InnerText;
                        tableArr[6] = issue.ChildNodes[3].InnerText;
                        tableArr[7] = issue.ChildNodes[4].InnerText;
                        tableArr[8] = issue.ChildNodes[5].InnerText;
                        tableArr[9] = issue.ChildNodes[6].InnerText;
                        tableArr[10] = node.Attributes["id"].Value;
                        tableArr[11] = node.Attributes["latitude"].Value;
                        tableArr[12] = node.Attributes["longitude"].Value;
                        tableArr[13] = node.Attributes["coordinate"].Value;
                        tableArr[14] = node.Attributes["type"].Value;
                        tableArr[15] = node.Attributes["region"].Value;
                        tableArr[16] = node.Attributes["level"].Value;
                        tableArr[17] = node.Attributes["description"].Value;
                        tableArr[18] = node.Attributes["domain"].Value;
                        tableArr[19] = node.Attributes["tags"].Value;
                        tableArr[20] = childNode.InnerText;
                        tableArr[21] = childNode.Attributes["xml:lang"].Value;
                        tableArr[22] = null;
                        tableArr[23] = null;
                        tableArr[24] = null;
                        tableArr[25] = null;
                        tableArr[26] = null;
                        tableArr[27] = null;
                        tableArr[28] = null;
                        tableArr[29] = null;
                        tableArr[30] = null;

                        foreach (var value in tableArr)
                        {
                            Console.Write(value + "|");
                        }
                        connect.Insert(tableArr);
                        Console.WriteLine(arrayCount);
                    }
                    else if (childNode.Name == "parameter")
                    {
                        foreach (XmlNode timerangeNode in childNode)
                        {
                            foreach (XmlNode valueNode in timerangeNode)
                            {
                                tableArr[0] = data.Attributes["source"].Value;
                                tableArr[1] = data.Attributes["productioncenter"].Value;
                                tableArr[2] = forecast.Attributes["domain"].Value;
                                tableArr[3] = issue.ChildNodes[0].InnerText;
                                tableArr[4] = issue.ChildNodes[1].InnerText;
                                tableArr[5] = issue.ChildNodes[2].InnerText;
                                tableArr[6] = issue.ChildNodes[3].InnerText;
                                tableArr[7] = issue.ChildNodes[4].InnerText;
                                tableArr[8] = issue.ChildNodes[5].InnerText;
                                tableArr[9] = issue.ChildNodes[6].InnerText;
                                tableArr[10] = node.Attributes["id"].Value;
                                tableArr[11] = node.Attributes["latitude"].Value;
                                tableArr[12] = node.Attributes["longitude"].Value;
                                tableArr[13] = node.Attributes["coordinate"].Value;
                                tableArr[14] = node.Attributes["type"].Value;
                                tableArr[15] = node.Attributes["region"].Value;
                                tableArr[16] = node.Attributes["level"].Value;
                                tableArr[17] = node.Attributes["description"].Value;
                                tableArr[18] = node.Attributes["domain"].Value;
                                tableArr[19] = node.Attributes["tags"].Value;
                                tableArr[20] = null;
                                tableArr[21] = null;
                                tableArr[22] = childNode.Attributes["id"].Value;
                                tableArr[23] = childNode.Attributes["description"].Value;
                                tableArr[24] = childNode.Attributes["type"].Value;
                                tableArr[25] = timerangeNode.Attributes["type"].Value;

                                if (childNode.Attributes["id"].Value == "hu" || childNode.Attributes["id"].Value == "t" || childNode.Attributes["id"].Value == "weather" || childNode.Attributes["id"].Value == "wd" || childNode.Attributes["id"].Value == "ws")
                                {
                                    tableArr[26] = timerangeNode.Attributes["h"].Value;
                                }
                                else if (childNode.Attributes["id"].Value == "humax" || childNode.Attributes["id"].Value == "tmax" || childNode.Attributes["id"].Value == "humin" || childNode.Attributes["id"].Value == "tmin")
                                {
                                    tableArr[26] = null;
                                }

                                tableArr[27] = timerangeNode.Attributes["datetime"].Value;

                                if (childNode.Attributes["id"].Value == "hu" || childNode.Attributes["id"].Value == "t" || childNode.Attributes["id"].Value == "weather" || childNode.Attributes["id"].Value == "wd" || childNode.Attributes["id"].Value == "ws")
                                {
                                    tableArr[28] = null;
                                }
                                else if (childNode.Attributes["id"].Value == "humax" || childNode.Attributes["id"].Value == "tmax" || childNode.Attributes["id"].Value == "humin" || childNode.Attributes["id"].Value == "tmin")
                                {
                                    tableArr[28] = timerangeNode.Attributes["day"].Value;
                                }

                                tableArr[29] = valueNode.InnerText;
                                tableArr[30] = valueNode.Attributes["unit"].Value;

                                foreach (var value in tableArr)
                                {
                                    Console.Write(value + "|");
                                }
                                connect.Insert(tableArr);
                                Console.WriteLine(arrayCount);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }
            Console.Write("Data Entry Succesfull --- Row Count = " + arrayCount);
        }
    }
}
