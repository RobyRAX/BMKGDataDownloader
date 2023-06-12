using System;
using System.Threading;

namespace ConnectDatabase
{
    class Program
    {
        public void Play()
        {
            Console.WriteLine("System Will Close in 10 Seconds");
            Timer t = new Timer(timerC, null, 10000, 10000);
        }

        private void timerC(object state)
        {
            Environment.Exit(0);
        }

        static void Main(string[] args)
        {
            XMLManagement manager = new XMLManagement();
            Connect connect = new Connect();
            ParseXML parseXML = new ParseXML();
            Program program = new Program();
            
            manager.DownloadXML();

            while (!manager.fileDownloaded)
            {
                if (manager.fileDownloaded)
                {
                    connect.Truncate();
                    parseXML.Parse();
                    break;
                }
            }          
            
            manager.MoveXML();
           
            program.Play();            
            Console.ReadLine();                      
        }                
    }
}